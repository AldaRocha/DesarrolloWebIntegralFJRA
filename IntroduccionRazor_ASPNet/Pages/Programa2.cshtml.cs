using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor_ASPNet.Pages
{
    public class Programa2Model : PageModel
    {
        [BindProperty]
        public string MensajeOriginal { get; set; } = string.Empty;
        [BindProperty]
        public int N { get; set; } = 0;
        public string MensajeCifrado { get; set; } = string.Empty;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string mensaje = MensajeOriginal.ToUpper();
            char[] resultado = new char[mensaje.Length];

            for (int i = 0; i < mensaje.Length; i++)
            {
                char caracter = mensaje[i];

                if (char.IsLetter(caracter))
                {
                    int indiceOriginal = 0;
                    while (indiceOriginal < alfabeto.Length && alfabeto[indiceOriginal] != caracter)
                    {
                        indiceOriginal++;
                    }

                    int nuevoIndice = (indiceOriginal + N) % alfabeto.Length;
                    resultado[i] = alfabeto[nuevoIndice];
                }
                else
                {
                    resultado[i] = caracter;
                }
            }

            int contador = 0;
            MensajeCifrado = "";
            do
            {
                MensajeCifrado += resultado[contador];
                contador++;
            } while (contador < resultado.Length);
        }
    }
}
