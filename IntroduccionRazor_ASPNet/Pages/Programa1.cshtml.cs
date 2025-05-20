using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages
{
    public class Programa1Model : PageModel
    {
        [BindProperty]
        public string Peso { get; set; } = "0";
        [BindProperty]
        public string Altura { get; set; } = "0";
        public decimal IMC { get; set; } = 0;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            decimal peso = Convert.ToDecimal(Peso);
            decimal altura = Convert.ToDecimal(Altura);
            if (altura > 0)
            {
                IMC = peso / (altura * altura);
            }
        }
    }
}