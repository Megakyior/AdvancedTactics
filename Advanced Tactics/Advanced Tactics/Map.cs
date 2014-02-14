﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced_Tactics
{
    class Map
    {
        private int H;
        private int W;
        private int[,] numero;
        private Case[,] carte;

        public static Case[,] map_creator(Case[,] carte, int H, int W, int[,] numero)
        {
            carte = new Case[H, W];
            // cree le tableau de case. Probleme avec constructeur a regler
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; i < W; j++)
                {
                    switch (numero[H,W])
                    {
                        case 0 :
                            carte[H, W] = new Case.case_constr(H, W, 0);
                            break;
                        case 1 :
                            carte[H, W] = new Case.case_constr(H, W, 1);
                            break;
                        case 2 :
                            carte[H, W] = new Case.case_constr(H, W, 2);
                            break;
                        case -1 :
                            carte[H, W] = new Case.case_constr(H, W, -1);
                            break;
                    }

                }
            }

        }

        


    }
}
