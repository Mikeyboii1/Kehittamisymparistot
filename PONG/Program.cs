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
            Raylib.SetTargetFPS(60);
            Vector2 player2 = new Vector2(700, 400);
            Vector2 player1 = new Vector2(50, 400);
            float speed = 1000.0f;
            float deltaTime = Raylib.GetFrameTime();
            while (Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                // Piirrä vasemman puoleinen maila.
                Raylib.DrawRectangleV(player1, new Vector2(20, 100), Color.White);


                //Piitträ oikean puoleinen maila.
                Raylib.DrawRectangleV(player2, new Vector2(20, 100), Color.Red);


                //liikuta mailoja ylös ja alas.
                if (Raylib.IsKeyDown(KeyboardKey.Up))
                {
                    player2.Y = player2.Y - speed * Raylib.GetFrameTime();
                }
                else if (Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    player2.Y = player2.Y + speed * Raylib.GetFrameTime();
                }

                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    player1.Y = player1.Y - speed * Raylib.GetFrameTime();
                }
                else if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    player1.Y = player1.Y + speed * Raylib.GetFrameTime();
                }


                // Piirrä pallo.

                Raylib.EndDrawing();
            }
        }
    }
}
