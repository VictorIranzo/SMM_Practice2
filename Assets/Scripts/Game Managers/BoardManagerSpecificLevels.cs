using System;
using UnityEngine;

namespace Completed
{
    public partial class BoardManager : MonoBehaviour
    {
        private string[,] GetLevel3()
        {
            string[,] level3 = new string[8, 8] {
                {   "",      "",     "",       "",    "",     "",  SENS,   ""},
                {   "",      "",     "",       "",    "",     "",    "", SENS},
                {   "",      "",     "",       "",    "",     "",    "",   ""},
                {   "",      "",     "",       "",    "",     "",    "",   ""},
                {   "",      "",     "",       "",    "",     "",    "",   ""},
                {   "",      "",  EMPTY,      "",    "",      "",    "",   ""},
                {   "",      "",     "",      "",    "",      "",    "",   ""},
                { EMPTY,     "",     "",      "",    "",      "",    "",   ""},
            };
            return Transpose(InvertRows(level3));
        }

        private string[,] GetLevel4()
        {
            string[,] level4 = new string[8, 8] {
                {EMPTY,    WALL,   EMPTY,    WALL,  EMPTY,  EMPTY,  EMPTY,  EMPTY},
                { SODA,    WALL,   EMPTY,    WALL,   SODA,   ROCK,   ROCK,  EMPTY},
                {EMPTY,    WALL,    ROCK,   EMPTY,   WALL,  EMPTY,  EMPTY,   WALL},
                {EMPTY,    ROCK,   EMPTY,   EMPTY,   ROCK,  EMPTY,  EMPTY,  EMPTY},
                {EMPTY,    WALL,    WALL,   EMPTY,   WALL,   WALL,   ROCK,   WALL},
                {EMPTY,    WALL,   EMPTY,   EMPTY,   WALL,  EMPTY,  EMPTY,  EMPTY},
                {EMPTY,    WALL,   EMPTY,   EMPTY,   WALL,  EMPTY,  EMPTY,  EMPTY},
                {EMPTY,    WALL,    SODA,    WALL,   SODA,  TRAMP,  EMPTY,   BUTT},
            }; 
            return Transpose(InvertRows(level4));
        }
  
        private string[,] GetLevel5()
        {
            string[,] level5 = new string[8, 8] {
                { EMPTY, EMPTY,  EMPTY,  EMPTY,  EMPTY,  EMPTY,  WALL,  EMPTY},
                { EMPTY,  WALL,   WALL,  EMPTY,   WALL,   WALL,  EMPTY, EMPTY},
                { EMPTY,  WALL,  SODA,   WALL,  EMPTY,   WALL,  EMPTY,  WALL},
                { EMPTY, EMPTY,  EMPTY,   WALL,  EMPTY,   WALL,  EMPTY, EMPTY},
                { EMPTY,  WALL,   WALL,  EMPTY,  EMPTY,  EMPTY,   WALL, EMPTY},
                { EMPTY,  WALL,  EMPTY,  EMPTY,   WALL,  EMPTY,   WALL, EMPTY},
                { EMPTY,  WALL,  EMPTY,   WALL,   WALL,  EMPTY,  EMPTY, EMPTY},
                { EMPTY, EMPTY,  EMPTY,  EMPTY,  EMPTY,   WALL,   WALL,  WALL},
            };
            return Transpose(InvertRows(level5));
        }

        private string[,] GetLevel6() {
            string[,] level6 = new string[8, 8] {
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",   WALL},
                { WALL,  WALL,   WALL,  TRAMP,   WALL,   WALL,   WALL,   WALL},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                {EMPTY,    "",  EMPTY,  EMPTY,     "",     "",  LEVER,     ""},
                {EMPTY, EMPTY,     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level6));
        }

        private string[,] GetLevel8()
        {
            string[,] level8 = new string[8, 8] {
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                { WALL,  WALL,     "",  EMPTY,     "",     "",     "",   WALL},
                {EMPTY,  SODA,   WALL,  TRAMP,   WALL,   WALL,   WALL,   WALL},
                {EMPTY,  ROCK,  EMPTY,  EMPTY,   WALL,  EMPTY,  EMPTY,   BUTT},
                {EMPTY, EMPTY,  EMPTY,  EMPTY,  EMPTY,  EMPTY,  EMPTY,   WALL},
                {EMPTY,  EMPTY,  EMPTY,  EMPTY, EMPTY,   EMPTY,  EMPTY,  EMPTY},
            };
            return Transpose(InvertRows(level8));
        }

        private string[,] GetLevel9()
        {
            string[,] level9 = new string[8, 8] {
                {   "",    "",     "",     "",     "",   WALL,     "",     ""},
                {   "",  FAKE,  LEVER,     "",     "",   FAKE,  TRAMP,   WALL},
                {   "",    "",   ROCK,     "",     "",     "",     "",   WALL},
                {   "",    "",     "",     "",     "",   FAKE,     "",   WALL},
                { FAKE,  FAKE,   FAKE,  EMPTY,  EMPTY,   FAKE,   FAKE,   FAKE},
                { ROCK,  ROCK,     "",  EMPTY,   WALL,     "",     "",     ""},
                {EMPTY,    "",     "",     "",     "",   FAKE,     "",   WALL},
                {EMPTY, EMPTY,     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level9));
        }

        private string[,] GetLevel10()
        {
            string[,] level10 = new string[8, 8] {
                { EMPTY, EMPTY, SODA,  EMPTY, TRAMP, EMPTY,  EMPTY,     EMPTY},
                { SODA,    EMPTY,   ROCK,   BUTT,   WALL,   WALL,   WALL,   ROCK},
                {EMPTY, EMPTY,   ROCK,  EMPTY,     EMPTY,     EMPTY,  EMPTY,     EMPTY},
                { WALL,  WALL,     EMPTY,  EMPTY,     EMPTY,     EMPTY,  EMPTY,   WALL},
                {   EMPTY,    EMPTY,   WALL,   WALL,   WALL,   WALL,   ROCK,   WALL},
                {   EMPTY,  ROCK,     EMPTY,  EMPTY,   WALL,     EMPTY,     EMPTY,   SODA},
                {   EMPTY,    EMPTY,     EMPTY,     EMPTY,     EMPTY,   WALL,     EMPTY,   WALL},
                {BLACK,    EMPTY,     EMPTY,     EMPTY,     EMPTY,     EMPTY,     EMPTY,     EMPTY},
            };
            return Transpose(InvertRows(level10));
        }

        private string[,] InvertRows(string[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            string[,] result = new string[w, h];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[i, j] = matrix[w - i - 1, j];
                }
            }

            return result;
        }

        public string[,] Transpose(string[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            string[,] result = new string[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

    }
}
