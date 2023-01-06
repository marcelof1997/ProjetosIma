using System;

namespace TicTacToe
{
    class Game
    {
        private List<Tuple<int, int>> GetPossibleMoves()
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == EMPTY)
                    {
                        moves.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return moves;
        }
        private int EvaluateBoard()
        {
            // Verifica se o jogador atual tem uma jogada que garante a vitória
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    return int.MaxValue;
                }

                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    return int.MaxValue;
                }
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                return int.MaxValue;
            }

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                return int.MaxValue;
            }

            // Verifica se o adversário tem uma jogada que garante a vitória
            int otherPlayer = currentPlayer == PLAYER_X ? PLAYER_O : PLAYER_X;
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == otherPlayer && board[i, 1] == otherPlayer && board[i, 2] == otherPlayer)
                {
                    return int.MinValue;
                }

                if (board[0, i] == otherPlayer && board[1, i] == otherPlayer && board[2, i] == otherPlayer)
                {
                    return int.MinValue;
                }
            }

            if (board[0, 0] == otherPlayer && board[1, 1] == otherPlayer && board[2, 2] == otherPlayer)
            {
                return int.MinValue;
            }

            if (board[0, 2] == otherPlayer && board[1, 1] == otherPlayer && board[2, 0] == otherPlayer)
            {
                return int.MinValue;
            }

            // Se não houver vencedor, retorna zero
            return 0;
        }


        // Constantes para representar o estado de cada posição no tabuleiro
        private const int EMPTY = 0;
        private const int PLAYER_X = 1;
        private const int PLAYER_O = 2;

        // Constantes para representar o vencedor
        private const int NOT_FINISHED = 0;
        private const int DRAW = 3;

        // O tabuleiro do jogo
        private int[,] board = new int[3, 3];

        // O jogador atual
        private int currentPlayer;

        // Inicializa o jogo
        public void Initialize()
        {
            // Inicializa o tabuleiro
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = EMPTY;
                }
            }

            // O jogador X começa
            currentPlayer = PLAYER_X;
        }

        // Lê a jogada do usuário
        public void ReadMove()
        {
            Console.WriteLine("Digite a linha e a coluna da sua jogada (separadas por um espaço):");
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            // Verifica se a jogada é válida
            if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != EMPTY)
            {
                Console.WriteLine("Jogada inválida");
                ReadMove();
                return;
            }

            // Realiza a jogada
            board[row, col] = currentPlayer;

            // Alterna o jogador atual
            currentPlayer = currentPlayer == PLAYER_X ? PLAYER_O : PLAYER_X;
        }

        // Faz a jogada da IA
        public void MakeAIMove()
        {
            // Obtém todas as jogadas possíveis
            List<Tuple<int, int>> moves = GetPossibleMoves();

            // Se não houver jogadas possíveis, a IA não faz nada
            if (moves.Count == 0)
            {
                return;
            }

            // Escolhe a melhor jogada possível usando a função de avaliação e busca em profundidade
            Tuple<int, int> bestMove = null;
            int bestScore = int.MinValue;
            foreach (Tuple<int, int> move in moves)
            {
                // Realiza a jogada temporariamente
                board[move.Item1, move.Item2] = currentPlayer;

                // Avalia o estado do tabuleiro
                int score = EvaluateBoard();

                // Desfaz a jogada
                board[move.Item1, move.Item2] = EMPTY;
            }
        }
    }
}