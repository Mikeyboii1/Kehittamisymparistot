using Raylib_cs;
using System.Numerics; // Vector2

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 600, "Starfield");
        Raylib.SetTargetFPS(60);

        // Luo satunnaisluku generaattori
        Random generator = new Random();

        //Taulukko murtolukuja jossa on 400 sanaa
        float[] posX = new float[400];
        //List<float> paikat = new List<float>(400);
        Star[] Stars = 
        // For silmukka joka käy kaikki luvut taulukossa läpi
        // For( ennen ; alussa ; lopussa)
        for (int index = 0; index < posX.Length; index += 1)
        {
            // Joakiselle satunnainen aloituspaikka
            posX[index] = generator.Next(-5, Raylib.GetScreenWidth());
        }

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            // Joka kerta, käy läpi koko posX taulukko
            // Kasvata jokaisen luvun arvoa, tarkista  onko luku
            // liian sio. Jos on liian iao, laita arvoksi -5

            for (int index = 0; index < posX.Length; index += 1)
            {
                posX[index] += 200 * Raylib.GetFrameTime();

                if (posX[index] > Raylib.GetScreenWidth())
                {
                    posX[index] = -5;
                }
                Raylib.DrawRectangle((int)posX[index], 10, 10, 10, Color.White);
            }

            Raylib.EndDrawing(); // Kaikki piirtäminen tätä ennen
        }
    }
}