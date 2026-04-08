using System.Numerics;
using Raylib_cs;

namespace SCREENSAVER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 A = new Vector2(100, 100);
            Vector2 Amove = new Vector2(1, 0);
            Vector2 B = new Vector2(300, 400);
            Vector2 Bmove = new Vector2(1, 0);
            Vector2 C = new Vector2(200, 400);
            Vector2 Cmove = new Vector2(1, 0);

            Raylib.InitWindow(800,800,"screensaver");
            while (Raylib.WindowShouldClose() == false)
            {
                float speed = 80.0f;
                float deltaTime = Raylib.GetFrameTime();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                A = A + Amove * speed * deltaTime;
                B = B + Bmove * speed * deltaTime;
                C = C + Cmove * speed * deltaTime;

                Amove = TarkistaReunat(A, Amove);
                Bmove = TarkistaReunat(B, Bmove);
                Cmove = TarkistaReunat(C, Cmove);

                Raylib.DrawLineV(A, B, Color.Yellow);
                Raylib.DrawLineV(B, C, Color.Red);
                Raylib.DrawLineV(C, A, Color.Green);
                Raylib.EndDrawing();

            }
            Raylib.CloseWindow();
        }

        private static Vector2 TarkistaReunat(Vector2 A, Vector2 Amove)
        {
            if (A.X > Raylib.GetScreenWidth())
            {
                Amove.X = -1.0f;
            }

            return Amove;
        }
    }
}
