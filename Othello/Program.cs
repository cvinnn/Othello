
public class Othello
{
    public string[,] board = new string[8, 8];
    private string playerChar = "";
    private string oppositeplayerChar = "";
    public int cekp1 = 2;
    public int cekp2 = 2;
    public void printboard()
    {
        Console.WriteLine();
        Console.WriteLine("################");
        Console.WriteLine("# Player Board #");
        Console.WriteLine("################");
        Console.WriteLine();
        Console.WriteLine($"|+|X|[1]+[2]+[3]+[4]+[5]+[6]+[7]+[8]|X|+|");
        Console.WriteLine($"|Y| +---+---+---+---+---+---+---+---+ |Y|");
        Console.WriteLine($"[1] + {board[0, 0]} + {board[1, 0]} + {board[2, 0]} + {board[3, 0]} + {board[4, 0]} + {board[5, 0]} + {board[6, 0]} + {board[7, 0]} + [1]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[2] + {board[0, 1]} + {board[1, 1]} + {board[2, 1]} + {board[3, 1]} + {board[4, 1]} + {board[5, 1]} + {board[6, 1]} + {board[7, 1]} + [2]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[3] + {board[0, 2]} + {board[1, 2]} + {board[2, 2]} + {board[3, 2]} + {board[4, 2]} + {board[5, 2]} + {board[6, 2]} + {board[7, 2]} + [3]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[4] + {board[0, 3]} + {board[1, 3]} + {board[2, 3]} + {board[3, 3]} + {board[4, 3]} + {board[5, 3]} + {board[6, 3]} + {board[7, 3]} + [4]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[5] + {board[0, 4]} + {board[1, 4]} + {board[2, 4]} + {board[3, 4]} + {board[4, 4]} + {board[5, 4]} + {board[6, 4]} + {board[7, 4]} + [5]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[6] + {board[0, 5]} + {board[1, 5]} + {board[2, 5]} + {board[3, 5]} + {board[4, 5]} + {board[5, 5]} + {board[6, 5]} + {board[7, 5]} + [6]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[7] + {board[0, 6]} + {board[1, 6]} + {board[2, 6]} + {board[3, 6]} + {board[4, 6]} + {board[5, 6]} + {board[6, 6]} + {board[7, 6]} + [7]");
        Console.WriteLine($"|+| +---+---+---+---+---+---+---+---+ |+|");
        Console.WriteLine($"[8] + {board[0, 7]} + {board[1, 7]} + {board[2, 7]} + {board[3, 7]} + {board[4, 7]} + {board[5, 7]} + {board[6, 7]} + {board[7, 7]} + [8]");
        Console.WriteLine($"|Y| +---+---+---+---+---+---+---+---+ |Y|");
        Console.WriteLine($"|+|X|[1]+[2]+[3]+[4]+[5]+[6]+[7]+[8]|X|+|");
        Console.WriteLine();
        Console.WriteLine($"#==================#");
        Console.WriteLine($"#  Notes :         #");
        Console.WriteLine($"#  P1 : {"0"}          #");
        Console.WriteLine($"#  P2 : {"O"}          #");
        Console.WriteLine($"#  Ex Input : 1,1  #");
        Console.WriteLine($"#==================#");
        Console.WriteLine();
    }

    public bool Move(int x, int y, bool turn)
    {
        bool cek = false;

        //check valid input
        if (x < 0 || y < 0 || x > 7 || y > 7)
        {
            cek = false;
            return cek;
        }

        if (board[x, y] != " ")
        {
            cek = false;
            return cek;
        }

        //player turn
        if (turn == true)
        {
            playerChar = "0";
        }
        else
        {
            playerChar = "O";
        }

        //opposite turn
        if (turn == true)
        {
            oppositeplayerChar = "O";
        }
        else
        {
            oppositeplayerChar = "0";
        }

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                //if 0,0 continue
                if (dx == 0 && dy == 0)
                {
                    continue;
                }
                if (x + dx < 0 || x + dx > 7 || y + dy < 0 || y + dy > 7)
                {
                    continue;
                }

                //if opposite = true
                if (board[x + dx, y + dy] == oppositeplayerChar)
                {
                    cek = true;
                    return cek;
                }
            }
        }
        return cek;
    }

    public List<string> MoveCoordinate(int x, int y, bool turn)
    {
        string headings = "";

        string[,] dxdyheading = new string[3, 3];

        int flipped = 0;

        List<string> headinglist = new List<string>();

        List<string> headinglists = new List<string>();

        //if heading
        /* dy -1  0  1 dx
         * -1 NW  N  NE 
         *  0  W  O  E
         *  1 SW  S  SE
         *  
         *  NW = -1,-1
         *  W  = -1, 0
         *  SW = -1, 1
         *  N  =  0,-1
         *  0+ =  0, 0
         *  S  =  0, 1
         *  NE =  1,-1
         *  E  =  1, 0
         *  SE =  1, 1
         */
        dxdyheading[0, 0] = "NW";
        dxdyheading[0, 1] = "W";
        dxdyheading[0, 2] = "SW";
        dxdyheading[1, 0] = "N";
        dxdyheading[1, 1] = "";
        dxdyheading[1, 2] = "S";
        dxdyheading[2, 0] = "NE";
        dxdyheading[2, 1] = "E";
        dxdyheading[2, 2] = "SE";

        //player turn
        if (turn == true)
        {
            playerChar = "0";
        }
        else
        {
            playerChar = "O";
        }

        //opposite turn
        if (turn == true)
        {
            oppositeplayerChar = "O";
        }
        else
        {
            oppositeplayerChar = "0";
        }

        //check heading
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                //if 0,0 continue
                if (dx == 0 && dy == 0)
                {
                    continue;
                }
                if (x + dx < 0 || x + dx > 7 || y + dy < 0 || y + dy > 7)
                {
                    continue;
                }
                if (board[x + dx, y + dy] == oppositeplayerChar)
                {
                    headings = dxdyheading[dx + 1, dy + 1];
                    headinglist.Add(headings);
                }
            }
        }
        foreach (string heading in headinglist)
        {
            int dx;
            int dy;
            int cekx = 0;
            int ceky = 0;
            int ax = 0;
            int ay = 0;
            switch (heading)
            {
                case "NW":
                    dx = -1;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continunw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gonw;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continunw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continunw:
                    continue;

                gonw:
                    headinglists.Add("NW");
                    break;

                case "W":
                    dx = -1;
                    dy = 0;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gow;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continuw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuw:
                    continue;

                gow:
                    headinglists.Add("W");
                    break;

                case "SW":
                    dx = -1;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continusw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gosw;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continusw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continusw:
                    continue;

                gosw:
                    headinglists.Add("SW");
                    break;

                case "N":
                    dx = 0;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continun;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gon;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continun;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continun:
                    continue;

                gon:
                    headinglists.Add("N");
                    break;

                case "S":
                    dx = 0;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continus;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gos;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continus;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continus:
                    continue;

                gos:
                    headinglists.Add("S");
                    break;

                case "NE":
                    dx = 1;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continune;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gone;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continune;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continune:
                    continue;

                gone:
                    headinglists.Add("NE");
                    break;

                case "E":
                    dx = 1;
                    dy = 0;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuee;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto goe;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continuee;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuee:
                    continue;

                goe:
                    headinglists.Add("E");
                    break;

                case "SE":
                    dx = 1;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuse;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gose;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            flipped++;
                            goto continuse;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuse:
                    continue;

                gose:
                    headinglists.Add("SE");
                    break;
            }

            if (flipped == 0)
            {
                continue;
            }
            if (flipped > 0)
            {
                flipped = 0;
                continue;
            }
        }
        return headinglists;
    }

    public void flipMove(List<string> headinglist, int x, int y, bool turn)
    {
        int dx;
        int dy;
        int flipped = 0;

        //player turn
        if (turn == true)
        {
            playerChar = "0";
        }
        else
        {
            playerChar = "O";
        }

        //opposite turn
        if (turn == true)
        {
            oppositeplayerChar = "O";
        }
        else
        {
            oppositeplayerChar = "0";
        }

        //foreach heading
        foreach (string heading in headinglist)
        {

            int cekx = 0;
            int ceky = 0;
            int ax = 0;
            int ay = 0;
            switch (heading)
            {
                case "NW":
                    dx = -1;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continunw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gonw;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            goto continunw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continunw:
                    continue;

                gonw:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "W":
                    dx = -1;
                    dy = 0;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gow;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            goto continuw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuw:
                    continue;

                gow:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "SW":
                    dx = -1;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continusw;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gosw;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            goto continusw;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continusw:
                    continue;

                gosw:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "N":
                    dx = 0;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continun;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gon;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            goto continun;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continun:
                    continue;

                gon:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "S":
                    dx = 0;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;
                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continus;
                        }
                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gos;
                        }
                        if (board[cekx, ceky] == " ")
                        {
                            goto continus;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continus:
                    continue;

                gos:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "NE":
                    dx = 1;
                    dy = -1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continune;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gone;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            goto continune;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continune:
                    continue;

                gone:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "E":
                    dx = 1;
                    dy = 0;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuee;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto goe;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            goto continuee;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuee:
                    continue;

                goe:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;

                case "SE":
                    dx = 1;
                    dy = 1;
                    cekx = x;
                    ceky = y;

                    do
                    {
                        cekx += dx;
                        ceky += dy;

                        if (cekx < 0 || cekx > 7 || ceky < 0 || ceky > 7)
                        {
                            goto continuse;
                        }

                        if (board[cekx, ceky] == playerChar)
                        {
                            goto gose;
                        }

                        if (board[cekx, ceky] == " ")
                        {
                            goto continuse;
                        }
                    } while (board[cekx, ceky] == oppositeplayerChar);

                continuse:
                    continue;

                gose:
                    flipped++;
                    ax = x;
                    ay = y;
                    while (board[ax + dx, ay + dy] == oppositeplayerChar)
                    {
                        board[ax, ay] = playerChar;
                        if (playerChar == "0")
                        {
                            cekp1++;
                        }
                        if (playerChar == "O")
                        {
                            cekp2++;
                        }
                        ax += dx;
                        ay += dy;
                    }
                    if (board[ax + dx, ay + dy] == playerChar)
                    {
                        board[ax, ay] = playerChar;
                        continue;
                    }
                    break;
            }
        }
        if (flipped > 0)
        {
            printboard();
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
    playagain:
        Othello othello = new Othello();
        List<string> headinglist = new List<string>();

        bool turn = true;
        bool cek;

        string p1 = "";
        string p2 = "";
        string rematch = "";

        int p1x;
        int p1y;
        int p2x;
        int p2y;
        int win = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                othello.board[i, j] = " ";
            }
        }

        othello.board[3, 3] = "O";
        othello.board[3, 4] = "0";
        othello.board[4, 3] = "0";
        othello.board[4, 4] = "O";

        do
        {
            if (turn == true)
            {
                othello.printboard();
            inputp1:
                headinglist.Clear();
                Console.WriteLine("Player 1 Turn");
                Console.WriteLine("Input Your Coordinate : ");
                Console.Write("> ");
                p1 = Console.ReadLine();
                Console.WriteLine($"---------------------------------");
                string p1try = p1.Replace(",", "");
                var num = int.TryParse(p1try, out _);
                if (p1.Length != 3 || num == false)
                {
                    Console.WriteLine("Invalid input. Re-Input");
                    Console.WriteLine($"---------------------------------");
                    goto inputp1;
                }
                else
                {
                    p1x = Convert.ToInt16(p1.Substring(0, 1));
                    p1y = Convert.ToInt16(p1.Substring(2, 1));
                    cek = othello.Move(p1x - 1, p1y - 1, true);
                }

            invalid:
                if (cek == false)
                {
                    Console.WriteLine("Invalid input. Re-Input");
                    Console.WriteLine($"---------------------------------");
                    goto inputp1;
                }

                //valid
                if (cek == true)
                {
                    headinglist = othello.MoveCoordinate(p1x - 1, p1y - 1, true);
                    if (headinglist.Count > 0)
                    {
                        othello.flipMove(headinglist, p1x - 1, p1y - 1, true);
                    }
                    else
                    {
                        cek = false;
                        goto invalid;
                    }
                }

                Console.Clear();
                turn = false;
            }
            if (turn == false)
            {
                othello.printboard();
            inputp2:
                headinglist.Clear();
                Console.WriteLine("Player 2 Turn");
                Console.WriteLine("Input Your Coordinate : ");
                Console.Write("> ");
                p2 = Console.ReadLine();
                Console.WriteLine($"---------------------------------");
                string p2try = p2.Replace(",", "");
                var num = int.TryParse(p2try, out _);
                if (p2.Length != 3 || num == false)
                {
                    Console.WriteLine("Invalid input. Re-Input");
                    Console.WriteLine($"---------------------------------");
                    goto inputp2;
                }
                else
                {
                    p2x = Convert.ToInt16(p2.Substring(0, 1));
                    p2y = Convert.ToInt16(p2.Substring(2, 1));
                    cek = othello.Move(p2x - 1, p2y - 1, false);
                }

            invalid:
                if (cek == false)
                {
                    Console.WriteLine("Invalid input. Re-Input");
                    Console.WriteLine($"---------------------------------");
                    goto inputp2;
                }

                //valid
                if (cek == true)
                {
                    headinglist = othello.MoveCoordinate(p2x - 1, p2y - 1, false);
                    if (headinglist.Count > 0)
                    {
                        othello.flipMove(headinglist, p2x - 1, p2y - 1, false);
                    }
                    else
                    {
                        cek = false;
                        goto invalid;
                    }
                }

                Console.Clear();
                turn = true;
            }
            if (othello.cekp1 + othello.cekp2 == 64 || othello.cekp1 == 0 || othello.cekp2 == 0)
            {
                break;
            }
        } while (othello.cekp1 + othello.cekp2 < 64 || othello.cekp1 > 0 || othello.cekp2 > 0);


        if (othello.cekp1 > othello.cekp2 || othello.cekp2 == 0)
        {
            Console.WriteLine($"P1 : {othello.cekp1}");
            Console.WriteLine($"P2 : {othello.cekp2}");
            Console.WriteLine("\r\n _______   __                                                  __          __       __  ______  __    __  __  __ \r\n|       \\ |  \\                                               _/  \\        |  \\  _  |  \\|      \\|  \\  |  \\|  \\|  \\\r\n| $$$$$$$\\| $$  ______   __    __   ______    ______        |   $$        | $$ / \\ | $$ \\$$$$$$| $$\\ | $$| $$| $$\r\n| $$__/ $$| $$ |      \\ |  \\  |  \\ /      \\  /      \\        \\$$$$        | $$/  $\\| $$  | $$  | $$$\\| $$| $$| $$\r\n| $$    $$| $$  \\$$$$$$\\| $$  | $$|  $$$$$$\\|  $$$$$$\\        | $$        | $$  $$$\\ $$  | $$  | $$$$\\ $$| $$| $$\r\n| $$$$$$$ | $$ /      $$| $$  | $$| $$    $$| $$   \\$$        | $$        | $$ $$\\$$\\$$  | $$  | $$\\$$ $$ \\$$ \\$$\r\n| $$      | $$|  $$$$$$$| $$__/ $$| $$$$$$$$| $$             _| $$_       | $$$$  \\$$$$ _| $$_ | $$ \\$$$$ __  __ \r\n| $$      | $$ \\$$    $$ \\$$    $$ \\$$     \\| $$            |   $$ \\      | $$$    \\$$$|   $$ \\| $$  \\$$$|  \\|  \\\r\n \\$$       \\$$  \\$$$$$$$ _\\$$$$$$$  \\$$$$$$$ \\$$             \\$$$$$$       \\$$      \\$$ \\$$$$$$ \\$$   \\$$ \\$$ \\$$\r\n                        |  \\__| $$                                                                               \r\n                         \\$$    $$                                                                               \r\n                          \\$$$$$$                                                                                \r\n");
            cek = false;
            win++;
        }
        if (othello.cekp1 == othello.cekp2)
        {
            Console.WriteLine($"P1 : {othello.cekp1}");
            Console.WriteLine($"P2 : {othello.cekp2}");
            Console.WriteLine("\r\n ____  ____  ____  _      _  _      _      ____    ____  _      _____   _      _  _        _____  _     _____   _____ ____  _      _____\r\n/  _ \\/  __\\/  _ \\/ \\  /|/ \\/ \\    / \\  /|/  _ \\  /  _ \\/ \\  /|/  __/  / \\  /|/ \\/ \\  /|  /__ __\\/ \\ /|/  __/  /  __//  _ \\/ \\__/|/  __/\r\n| | \\||  \\/|| / \\|| |  ||| || |    | |\\ ||| / \\|  | / \\|| |\\ |||  \\    | |  ||| || |\\ ||    / \\  | |_|||  \\    | |  _| / \\|| |\\/|||  \\  \r\n| |_/||    /| |-||| |/\\||\\_/\\_/__  | | \\||| \\_/|  | \\_/|| | \\|||  /_   | |/\\||| || | \\||    | |  | | |||  /_   | |_//| |-||| |  |||  /_ \r\n\\____/\\_/\\_\\\\_/ \\|\\_/  \\|(_)(_)\\/  \\_/  \\|\\____/  \\____/\\_/  \\|\\____\\  \\_/  \\|\\_/\\_/  \\|    \\_/  \\_/ \\|\\____\\  \\____\\\\_/ \\|\\_/  \\|\\____\\\r\n                                                                                                                                        \r\n");
            cek = false;
            win++;
        }
        if (othello.cekp1 < othello.cekp2 || othello.cekp1 == 0)
        {
            Console.WriteLine($"P1 : {othello.cekp1}");
            Console.WriteLine($"P2 : {othello.cekp2}");
            Console.WriteLine("\r\n _______   __                                                 ______         __       __  ______  __    __  __  __ \r\n|       \\ |  \\                                               /      \\       |  \\  _  |  \\|      \\|  \\  |  \\|  \\|  \\\r\n| $$$$$$$\\| $$  ______   __    __   ______    ______        |  $$$$$$\\      | $$ / \\ | $$ \\$$$$$$| $$\\ | $$| $$| $$\r\n| $$__/ $$| $$ |      \\ |  \\  |  \\ /      \\  /      \\        \\$$__| $$      | $$/  $\\| $$  | $$  | $$$\\| $$| $$| $$\r\n| $$    $$| $$  \\$$$$$$\\| $$  | $$|  $$$$$$\\|  $$$$$$\\       /      $$      | $$  $$$\\ $$  | $$  | $$$$\\ $$| $$| $$\r\n| $$$$$$$ | $$ /      $$| $$  | $$| $$    $$| $$   \\$$      |  $$$$$$       | $$ $$\\$$\\$$  | $$  | $$\\$$ $$ \\$$ \\$$\r\n| $$      | $$|  $$$$$$$| $$__/ $$| $$$$$$$$| $$            | $$_____       | $$$$  \\$$$$ _| $$_ | $$ \\$$$$ __  __ \r\n| $$      | $$ \\$$    $$ \\$$    $$ \\$$     \\| $$            | $$     \\      | $$$    \\$$$|   $$ \\| $$  \\$$$|  \\|  \\\r\n \\$$       \\$$  \\$$$$$$$ _\\$$$$$$$  \\$$$$$$$ \\$$             \\$$$$$$$$       \\$$      \\$$ \\$$$$$$ \\$$   \\$$ \\$$ \\$$\r\n                        |  \\__| $$                                                                                 \r\n                         \\$$    $$                                                                                 \r\n                          \\$$$$$$                                                                                  \r\n");
            cek = false;
            win++;
        }

        if (win > 0)
        {
            Console.WriteLine();
            Console.WriteLine("\r\n  _______    _______  ___      ___       __  ___________  ______    __    __  ________   \r\n /\"      \\  /\"     \"||\"  \\    /\"  |     /\"\"\\(\"     _   \")/\" _  \"\\  /\" |  | \"\\(\"      \"\\  \r\n|:        |(: ______) \\   \\  //   |    /    \\)__/  \\\\__/(: ( \\___)(:  (__)  :)\\___/   :) \r\n|_____/   ) \\/    |   /\\\\  \\/.    |   /' /\\  \\  \\\\_ /    \\/ \\      \\/      \\/   /  ___/  \r\n //      /  // ___)_ |: \\.        |  //  __'  \\ |.  |    //  \\ _   //  __  \\\\  //  \\     \r\n|:  __   \\ (:      \"||.  \\    /:  | /   /  \\\\  \\\\:  |   (:   _) \\ (:  (  )  :)('___/     \r\n|__|  \\___) \\_______)|___|\\__/|___|(___/    \\___)\\__|    \\_______) \\__|  |__/  (___)     \r\n  ________  ___  ___  ________       ___  ___  _______   ________                        \r\n /\"      \")|\"  \\/\"  |(\"      \"\\     |\"  \\/\"  |/\"     \"| /\"       )                       \r\n(:   \\___/  \\   \\  /  \\___/   :)     \\   \\  /(: ______)(:   \\___/                        \r\n//   /       \\\\  \\/       \\   \\\\      \\\\  \\/  \\/    |   \\___  \\                          \r\n\\\\   \\___    /   /     ___/   //      /   /   // ___)_   __/  \\\\                         \r\n(:   /  \"\\  /   /     /\"  \\   :)     /   /   (:      \"| /\" \\   :)                        \r\n \\________)|___/     (________/     |___/     \\_______)(_______/                         \r\n  ________  _____  ___   ________       _____  ___      ______                           \r\n /\"      \")(\\\"   \\|\"  \\ (\"      \"\\     (\\\"   \\|\"  \\    /    \" \\                          \r\n(:   \\___/ |.\\\\   \\    | \\___/   :)    |.\\\\   \\    |  // ____  \\                         \r\n//   /     |: \\.   \\\\  |     \\   \\\\    |: \\.   \\\\  | /  /    ) :)                        \r\n\\\\   \\___  |.  \\    \\. |  ___/   //    |.  \\    \\. |(: (____/ //                         \r\n(:   /  \"\\ |    \\    \\ | /\"  \\   :)    |    \\    \\ | \\        /                          \r\n \\________) \\___|\\____\\)(________/      \\___|\\____\\)  \\\"_____/                           \r\n                                                                                         \r\n");
            Console.Write("> ");
            rematch = Console.ReadLine().ToUpper();

            if (rematch.ToUpper() == "Y")
            {
                win = 0;
                Console.Clear();
                goto playagain;
            }
            else if (rematch.ToUpper() == "N")
            {
                Console.WriteLine(" ____ ____ ____ ____ ____ ____ ____ ____ _________ ____ ____ ____ _________ ____ ____ ____ ____ ____ ____ ____ _________ ____ ____ ____ _________ ____ ____ ____ ____ ____ ____ \r\n||T |||h |||a |||n |||k |||y |||o |||u |||       |||F |||o |||r |||       |||P |||l |||a |||y |||i |||n |||g |||       |||T |||h |||e |||       |||G |||a |||m |||e |||! |||! ||\r\n||__|||__|||__|||__|||__|||__|||__|||__|||_______|||__|||__|||__|||_______|||__|||__|||__|||__|||__|||__|||__|||_______|||__|||__|||__|||_______|||__|||__|||__|||__|||__|||__||\r\n|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/_______\\|/__\\|/__\\|/__\\|/_______\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/_______\\|/__\\|/__\\|/__\\|/_______\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|");
                Environment.Exit(0);
            }
        }
        Console.ReadKey();
    }
}