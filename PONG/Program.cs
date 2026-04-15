using System.Numerics;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace PONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 800, "screensaver");
            Raylib.SetTargetFPS(30);
            Vector2 player1 = new Vector2(50, 400);
            while (Raylib.WindowShouldClose() == false)
            {
                float speed = 80.0f;
                float deltaTime = Raylib.GetFrameTime();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                // Piirrä vasemman puoleinen maila.
                Raylib.DrawRectangleV(player1, new Vector2(20, 100), Color.White);


                //Piitträ oikean puoleinen maila.


                //liikuta mailoja ylös ja alas.
                if (Raylib.IsKeyDown(KeyboardKey.Up))
                {
                    player1.Y = player1.Y - speed * Raylib.GetFrameTime();
                }
                else if (Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    player1.Y = player1.Y + speed * Raylib.GetFrameTime();
                }


                // Piirrä pallo.

                Raylib.EndDrawing();
            }
        }
    }
}
