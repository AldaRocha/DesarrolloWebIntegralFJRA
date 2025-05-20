using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public int N { get; set; }
        public double Resultado { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Resultado = 0;
            int k = 0;

            do
            {
                double coeficiente = Factorial(N) / (Factorial(k) * Factorial(N - k));
                double termino = coeficiente * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                Resultado += termino;
                k++;
            } while (k <= N);
        }

        private long Factorial(int num)
        {
            if (num == 0 || num == 1) return 1;

            long fact = 1;
            int i = 2;
            while (i <= num)
            {
                fact *= i;
                i++;
            }
            return fact;
        }
    }
}
