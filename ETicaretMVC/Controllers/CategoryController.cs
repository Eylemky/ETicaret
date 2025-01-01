using ETicaretEntity.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ETicaretMVC.Controllers
{

    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        // Constructor injection for IHttpClientFactory
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // List categories
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _httpClient.GetFromJsonAsync<List<Category>>("/api/category/index");
                return View(categories);
            }
            catch (Exception ex)
            {
                // Log error (optional)
                // Return an error view or message
                ViewBag.ErrorMessage = "Kategoriler yüklenirken bir hata oluştu.";
                return View(new List<Category>()); // Boş liste döner
            }
        }

        // Display Create form
        public IActionResult Create()
        {
            return View(new Category());
        }

        // Handle Create form submission
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category); // Validation hataları varsa tekrar form gösterilir
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/category/insert", category);

                if (response.IsSuccessStatusCode)
                {
                    // Başarılı durum, kullanıcıyı listeye yönlendir
                    return RedirectToAction(nameof(Index));
                }

                // API hatalarını çözümlemek için JSON'u ayrıştır
                var responseString = await response.Content.ReadAsStringAsync();
                var apiResult = JsonSerializer.Deserialize<ApiResult>(responseString);

                if (apiResult?.errors != null)
                {
                    foreach (var error in apiResult.errors)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Bilinmeyen bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                // Log error (optional)
                ModelState.AddModelError(string.Empty, "Bir hata oluştu. Lütfen tekrar deneyin.");
            }

            return View(category); // Hatalar varsa aynı sayfaya dön
        }

        // API sonucu için model
        public class ApiResult
        {
            public string type { get; set; }
            public int status { get; set; }
            public Dictionary<string, string> errors { get; set; }
            public string traceId { get; set; }
            public bool hasError { get; set; }
        }
    }
}
