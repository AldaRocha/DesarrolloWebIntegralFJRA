using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages
{
    public class Programa4Model : PageModel
    {
        public List<int> Numeros { get; set; } = new();
        public List<int> NumerosOrdenados { get; set; } = new();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new();
        public double Mediana { get; set; }

        public void OnGet()
        {
            Random random = new Random();
            Numeros = Enumerable.Range(1, 20).Select(_ => random.Next(0, 101)).ToList();
            NumerosOrdenados = Numeros.OrderBy(n => n).ToList();

            Suma = Numeros.Sum();
            Promedio = Suma / (double)Numeros.Count;

            var frecuencia = Numeros.GroupBy(n => n).OrderByDescending(g => g.Count());
            int maxFrecuencia = frecuencia.First().Count();
            Moda = frecuencia.Where(g => g.Count() == maxFrecuencia).Select(g => g.Key).ToList();

            int mitad = NumerosOrdenados.Count / 2;
            Mediana = NumerosOrdenados.Count % 2 == 0 ? (NumerosOrdenados[mitad - 1] + NumerosOrdenados[mitad]) / 2.0 : NumerosOrdenados[mitad];
        }
    }
}
