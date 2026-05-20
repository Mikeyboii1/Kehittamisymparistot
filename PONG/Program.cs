using System.Numerics;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace PONG
{
    internal class Program
    {
        // Pelaajien sijainnit
        Vector2 player1;
        Vector2 player2;

        // Pelaajien pisteet
        int player1Score = 0;
        int player2Score = 0;

        // Mailan koko ja nopeus
        Vector2 playerSize = new Vector2(20, 100);
        float playerSpeed = 500;

        // Pallon tiedot
        Vector2 ballPosition;
        Vector2 ballDirection;
        float ballSpeed = 400;

        // Ruudun koko
        int screenWidth = 800;
        int screenHeight = 800;

        static void Main(string[] args)
        {
            Program pong = new Program();
            pong.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(screenWidth, screenHeight, "PONG");
            Raylib.SetTargetFPS(60);

            InitializeGame();

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void InitializeGame()
        {
            int playerToWall = 60;

            // Pelaajien paikat
            player1 = new Vector2(
                playerToWall,
                screenHeight / 2 - playerSize.Y / 2
            );

            player2 = new Vector2(
                screenWidth - playerSize.X - playerToWall,
                screenHeight / 2 - playerSize.Y / 2
            );

            ResetBall();
        }

        void ResetBall()
        {
            // Pallo keskelle
            ballPosition = Raylib.GetScreenCenter();

            // Pallon suunta
            ballDirection = Vector2.Normalize(new Vector2(1, 0.5f));
        }

        void Update()
        {
            MovePlayers();
            MoveBall();
            CheckBallCollisions();
        }

        void MovePlayers()
        {
            float deltaTime = Raylib.GetFrameTime();

            // Pelaaja 1 (W/S)
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                player1.Y -= playerSpeed * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                player1.Y += playerSpeed * deltaTime;
            }

            // Pelaaja 2 (Nuolinäppäimet)
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                player2.Y -= playerSpeed * deltaTime;
            }

            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                player2.Y += playerSpeed * deltaTime;
            }

            // Estä kentän ulkopuolelle meneminen
            ClampPlayers();
        }

        void ClampPlayers()
        {
            // Pelaaja 1
            if (player1.Y < 0)
            {
                player1.Y = 0;
            }
            else if (player1.Y + playerSize.Y > screenHeight)
            {
                player1.Y = screenHeight - playerSize.Y;
            }

            // Pelaaja 2
            if (player2.Y < 0)
            {
                player2.Y = 0;
            }
            else if (player2.Y + playerSize.Y > screenHeight)
            {
                player2.Y = screenHeight - playerSize.Y;
            }
        }

        void MoveBall()
        {
            ballPosition += ballDirection * ballSpeed * Raylib.GetFrameTime();
        }

        void CheckBallCollisions()
        {
            // Ylä- ja alareuna
            if (ballPosition.Y <= 0 || ballPosition.Y >= screenHeight)
            {
                ballDirection.Y *= -1;
            }

            Rectangle player1Rectangle = new Rectangle(player1, playerSize);
            Rectangle player2Rectangle = new Rectangle(player2, playerSize);

            // Törmäys pelaajaan 1
            if (Raylib.CheckCollisionPointRec(ballPosition, player1Rectangle))
            {
                ballDirection.X *= -1;

                // Työnnä pallo ulos mailasta
                ballPosition.X = player1.X + playerSize.X;
            }

            // Törmäys pelaajaan 2
            if (Raylib.CheckCollisionPointRec(ballPosition, player2Rectangle))
            {
                ballDirection.X *= -1;

                // Työnnä pallo ulos mailasta
                ballPosition.X = player2.X;
            }

            // Vasen reuna -> pelaaja 2 saa pisteen
            if (ballPosition.X < 0)
            {
                player2Score++;
                ResetBall();
            }

            // Oikea reuna -> pelaaja 1 saa pisteen
            if (ballPosition.X > screenWidth)
            {
                player1Score++;
                ResetBall();
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Black);

            // Pelaajat
            Raylib.DrawRectangleV(player1, playerSize, Color.White);
            Raylib.DrawRectangleV(player2, playerSize, Color.Red);

            // Pallo
            Raylib.DrawCircleV(ballPosition, 10, Color.White);

            // Pisteet
            Raylib.DrawText(
                player1Score.ToString(),
                screenWidth / 4,
                20,
                40,
                Color.White
            );

            Raylib.DrawText(
                player2Score.ToString(),
                screenWidth * 3 / 4,
                20,
                40,
                Color.White
            );

            Raylib.EndDrawing();
        }
    }
}