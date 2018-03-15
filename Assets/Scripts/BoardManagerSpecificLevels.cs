using System;
using UnityEngine;

namespace Completed
{
    public partial class BoardManager : MonoBehaviour
    {
        private string[,] GetLevel1()
        {
            string[,] level1 = new string[8, 8] {
                {EMPTY,    WALL,   EMPTY,    WALL,     "",  EMPTY,     "",     ""},
                { SODA,    WALL,   EMPTY,    WALL,   SODA,   ROCK,  ROCK,   EMPTY},
                {EMPTY,    WALL,    ROCK,   EMPTY,   WALL,     "",  EMPTY,   WALL},
                {EMPTY,    ROCK,   EMPTY,   EMPTY,   ROCK,  EMPTY,  EMPTY,  EMPTY},
                {EMPTY,    WALL,    WALL,   EMPTY,   WALL,   WALL,   ROCK,   WALL},
                {EMPTY,    WALL,      "",   EMPTY,   WALL,     "",   EMPTY, EMPTY},
                {EMPTY,    WALL,      "",   EMPTY,   WALL,     "",   EMPTY, EMPTY},
                {EMPTY,    WALL,    SODA,    WALL,   SODA,  TRAMP,     "",   BUTT},
            }; 
            return Transpose(InvertRows(level1));
        }


        private string[,] GetLevel2()
        {
            string[,] level1 = new string[8, 8] {
                { EMPTY, EMPTY,  EMPTY,  EMPTY,  EMPTY,  EMPTY,  WALL,  EMPTY},
                { EMPTY,  WALL,   WALL,  EMPTY,   WALL,   WALL,  EMPTY, EMPTY},
                { EMPTY,  WALL,  SODA,   WALL,  EMPTY,   WALL,  EMPTY,  WALL},
                { EMPTY, EMPTY,  EMPTY,   WALL,  EMPTY,   WALL,  EMPTY, EMPTY},
                { EMPTY,  WALL,   WALL,  EMPTY,  EMPTY,  EMPTY,   WALL, EMPTY},
                { EMPTY,  WALL,  EMPTY,  EMPTY,   WALL,  EMPTY,   WALL, EMPTY},
                { EMPTY,  WALL,  EMPTY,   WALL,   WALL,  EMPTY,  EMPTY, EMPTY},
                { EMPTY, EMPTY,  EMPTY,  EMPTY,  EMPTY,   WALL,   WALL,  WALL},
            };
            return Transpose(InvertRows(level1));
        }

        private string[,] GetLevel3() {
            string[,] level1 = new string[8, 8] {
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",   WALL},
                { WALL,  WALL,   WALL,  TRAMP,   WALL,   WALL,   WALL,   WALL},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                {   "",    "",  EMPTY,  EMPTY,     "",     "",  LEVER,     ""},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level1));
        }

        private string[,] GetLevel4()
        {
            string[,] level1 = new string[8, 8] {
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
                {   "",    "",     "",  EMPTY,     "",     "",     "",     ""},
                { WALL,  WALL,     "",  EMPTY,     "",     "",     "",   WALL},
                {   "",    "",   WALL,  TRAMP,   WALL,   WALL,   WALL,   WALL},
                {   "",  ROCK,     "",  EMPTY,   WALL,     "",     "",   BUTT},
                {   "",    "",  EMPTY,  EMPTY,     "",     "",     "",   WALL},
                {   "",    "",     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level1));
        }

        private string[,] GetLevel5()
        {
            string[,] level1 = new string[8, 8] {
                {   "",    "",     "",     "",     "",   WALL,     "",     ""},
                {   "",  FAKE,  LEVER,     "",     "",   FAKE,  TRAMP,   WALL},
                {   "",    "",   ROCK,     "",     "",     "",     "",   WALL},
                {   "",    "",     "",     "",     "",   FAKE,     "",   WALL},
                { FAKE,  FAKE,   FAKE,  EMPTY,  EMPTY,   FAKE,   FAKE,   FAKE},
                { ROCK,  ROCK,     "",  EMPTY,   WALL,     "",     "",     ""},
                {   "",    "",     "",     "",     "",   FAKE,     "",   WALL},
                {EMPTY,    "",     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level1));
        }

        private string[,] GetLevel6()
        {
            string[,] level1 = new string[8, 8] {
                {   "",    "",   SODA,     "",  TRAMP,  EMPTY,     "",     ""},
                { SODA,    "",   ROCK,   BUTT,   WALL,   WALL,   WALL,   ROCK},
                {EMPTY, EMPTY,   ROCK,  EMPTY,     "",     "",  EMPTY,     ""},
                { WALL,  WALL,     "",  EMPTY,     "",     "",  EMPTY,   WALL},
                {   "",    "",   WALL,   WALL,   WALL,   WALL,   ROCK,   WALL},
                {   "",  ROCK,     "",  EMPTY,   WALL,     "",     "",   SODA},
                {   "",    "",     "",     "",     "",   WALL,     "",   WALL},
                {BLACK,    "",     "",     "",     "",     "",     "",     ""},
            };
            return Transpose(InvertRows(level1));
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
