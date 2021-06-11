using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var iAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                         System.Console.WriteLine("Informe o nome do aluno: ");
                         var aluno =  new Aluno();
                         aluno.Nome  = Console.ReadLine();
                    
                         System.Console.WriteLine( "Informe a nota do aluno");
                         if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                          {
                          aluno.Nota = nota;
                          }
                         else
                         {
                             throw new ArgumentException("Valor da nota deve ser em decimal!");
                         }
                            alunos[iAluno] = aluno;
                            iAluno++;

                        break;
                    case "2":
                         foreach(var a in alunos)
                            {   if(!string.IsNullOrEmpty(a.Nome))
                               {
                                 System.Console.WriteLine( $"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                               }
                           }
                        break;
                    case "3":
                             decimal notaTotal = 0;
                             var nrAlunos = 0;

                         for(int i=0; i < alunos.Length; i++)
                            {
                                    if(!string.IsNullOrEmpty(alunos[i].Nome))
                                    {
                                notaTotal +=  alunos[i].Nota;
                                nrAlunos++;
                              }
                             }
                         var mediaGeral = notaTotal / nrAlunos;
                         ConceitoEnum conceitoGeral;
                            if(mediaGeral < 3)
                            {
                                conceitoGeral = ConceitoEnum.E;
                            }
                            else if(mediaGeral < 5)
                            {
                                conceitoGeral = ConceitoEnum.D;
                            }
                            else if(mediaGeral < 6)
                            {
                                conceitoGeral = ConceitoEnum.C;
                            }
                            else if(mediaGeral < 8)
                            {
                                conceitoGeral = ConceitoEnum.B;
                            }
                            else
                            {
                                conceitoGeral = ConceitoEnum.A;
                            }

                         System.Console.WriteLine($"MÉDIA GERAL É:  {mediaGeral} - CONCEITO É: {conceitoGeral}");
                        break;
                    default:

                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine("Informe a opção desejada");
            System.Console.WriteLine("1 - Inserir novo aluno");
            System.Console.WriteLine("2 - Listar Alunos");
            System.Console.WriteLine("3 - Calcular média geral");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
