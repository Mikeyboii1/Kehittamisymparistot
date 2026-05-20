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

            // Pallon aloituspaikka on ruudun keskellä
            Vector2 ballPosition = Raylib.GetScreenCenter();

            // Pallon suunta normalisoidaan että sen pituudeksi tulee 1
            Vector2 ballDirection = Vector2.Normalize(new Vector2(1, 0.5f));

            // Pallon nopeuden yksikkö on pikseleitä sekunnissa
            float ballSpeed = 160;

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
                    if (IsTouchingUp(player2) == false)
                    {
                        player2.Y = player2.Y - speed * Raylib.GetFrameTime();
                    }
                }
                else if (Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    if (IsTouchingDown(player2) == false)
                    {
                        player2.Y = player2.Y + speed * Raylib.GetFrameTime();
                    }
                }

                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    if (IsTouchingUp(player1) == false)
                    {
                        player1.Y = player1.Y - speed * Raylib.GetFrameTime();
                    }
                }
                else if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    if (IsTouchingDown(player1) == false)
                    {
                        player1.Y = player1.Y + speed * Raylib.GetFrameTime();
                    }
                }


                Raylib.DrawCircleV(ballPosition, 20 , Color.White);

                Raylib.EndDrawing();


                ballPosition = ballPosition + ballDirection * ballSpeed * Raylib.GetFrameTime();
            }
        }
        static bool IsTouchingSomething(Vector2 v)
        {
            if (IsTouchingUp(v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool IsTouchingUp(Vector2 v)
        {
            if (v.Y > 0)
            { 
                return false;
            }
            else
            {
                return true; 
            }
        }
        static bool IsTouchingDown(Vector2 v)
        {
            if( (v.Y + 100 ) > Raylib.GetScreenHeight())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
