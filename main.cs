using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sintese
{
    class MeuDeck
    {

        public class Cartas
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public abstract class Carta
        {
            protected string[] valores = { "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Valete", "Dama", "Rei",
                "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Valete", "Dama", "Rei", "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Valete", "Dama", "Rei",
                "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Valete", "Dama", "Rei", "Coringa", "Coringa" };

            protected string[] naipes = { "Paus", "Copas", "Ouros", "Espadas" };

            protected List<Cartas> oBaralho = new List<Cartas>();
            protected List<Cartas> oDescarte = new List<Cartas>();
            protected List<Cartas> emOrdem = new List<Cartas>();

            public Carta() { }
        }

        public class MonteDeCartas : Carta
        {
            private Random num_Aleatorio;
            int n = 0;
            int count = 0;
            int contagem = 0;


            public void BaralhoInicial()
            {
                for (int i = 0; i < 54; i++)
                {
                    if (i > 12 && i < 25)
                    {
                        n = 1;
                    }
                    else if (i > 25 && i < 38)
                    {
                        n = 2;
                    }
                    else if (i > 38)
                    {
                        n = 3;
                    };
                    if (valores[i] == "Coringa")
                    {
                        oBaralho.Add(new Cartas { Id = i, Nome = "Coringa" });
                    }
                    else
                        oBaralho.Add(new Cartas { Id = i, Nome = "" + valores[i] + " de " + naipes[n] });
                }
            }

            public void BaralhoInicial2()
            {
                for (int i = 0; i < 54; i++)
                {
                    if (i > 12 && i < 25)
                    {
                        n = 1;
                    }
                    else if (i > 25 && i < 38)
                    {
                        n = 2;
                    }
                    else if (i > 38)
                    {
                        n = 3;
                    };
                    if (valores[i] == "Coringa")
                    {
                        emOrdem.Add(new Cartas { Id = i, Nome = "Coringa" });
                    }
                    else
                        emOrdem.Add(new Cartas { Id = i, Nome = "" + valores[i] + " de " + naipes[n] });
                }
            }


            public void OlharBaralho()
            {
                Console.WriteLine("");
                foreach (var Carta in oBaralho)
                {
                    Console.WriteLine($"{count++ + 1} {Carta.Nome}");
                }
                count = 0;
            }

            public void Descarte()
            {

                if (oBaralho.Count == 0)
                {
                    Console.WriteLine("\n** O Baralho está vazio! **");
                }
                else
                {
                    oDescarte.Add(new Cartas { Id = oDescarte.Count - 1, Nome = oBaralho[contagem].Nome });
                    Console.WriteLine("\n\nCarta na Pilha de Descarte: " + oBaralho[contagem].Nome);

                    for (int i = 0; i < emOrdem.Count; i++)
                    {
                        if (emOrdem[i].Nome == oBaralho[contagem].Nome)
                        {
                            Console.WriteLine("\n\nRemovendo de Ordenado: " + emOrdem[i].Nome);
                            emOrdem.RemoveAt(i);
                        }
                    }

                    oBaralho.RemoveAt(contagem);
                    contagem++;
                }

            }

            public void Esconder()
            {
                oBaralho.Add(new Cartas { Id = oBaralho.Count, Nome = oDescarte[oDescarte.Count - 1].Nome });
                oDescarte.RemoveAt(oDescarte.Count - 1);
            }

            public void Ordenar()
            {
                Console.WriteLine("");
                foreach (var Carta in emOrdem)
                {
                    Console.WriteLine($"{count++ + 1} {Carta.Nome}");
                }
                count = 0;
            }

            public void Embaralhar()
            {
                num_Aleatorio = new Random();
                for (int primeira = 0; primeira < oBaralho.Count; primeira++)
                {
                    int segunda = num_Aleatorio.Next(oBaralho.Count);
                    Cartas Temp = oBaralho[primeira];
                    oBaralho[primeira] = oBaralho[segunda];
                    oBaralho[segunda] = Temp;
                }
            }

        }

        static void Main(string[] args)
        {
            bool game = true;
            int olhado = 0, descartado = 0, errou = 0, ordenador = 0, embaralhado = 0, merito = 0;
            string resposta;
            string menu;

            Console.WriteLine("Sintese Geral 8 - Bruno Neves Oliveira\n\n\n" +
                "                                ****O Baralho Mágico da Terra Encantada****" +
"\n\nVocê foi dormir pela noite, mas quando acordou se deparou com cenas fantásticas. Elefantes dançantes, faquires encantando serpentes acima de tapetes voadores e " +
"o chão quadriculado sob seus pés parecia um... tabuleiro de xadrez? Escapando por uma triz de um ataque diagonalizado de um bispo fora de controle, você corre para se esconder numa tenda próxima, sem ter tempo de notar o que diziam as faixas coloridas acima da entrada. \n\n" +
"Dentro da tenda uma velha cigana atrás de uma mesa coberta com uma toalha vermelha puída lhe observa com divertimento. " +
"Você tem a impressão que havia até um leve sorrisinho debochado puxando a pele caída ao redor dos lábios da velha quando entrou, mas num segundo olhar ele não está mais ali," +
"apenas um olhar cansado, tão cansado quanto o mundo, aqueles olhares que árvores antiguíssimas olhariam, se tivessem olhos que conseguíssemos ver. Finalmente repara que ela está " +
"manuseando um baralho de imagens estranhas com destreza que parece humanamente impossível. E como você não reparou no Baralho antes? Ele é facilmente a coisa mais chamativa" +
" de toda a tenda...\n\nO padrão hipnótico do baralho sendo embaralhado e re-embaralhado, som das cartas se chocando, lentamente lhe trazem a sensação de clareza e cansaço simultaneamente, " +
"como se você conseguisse pensar mil coisas, porém claramente sua mente estivesse reclamando dessa súbita explosão e lhe cochichasse que não possuía tanto horsepower para tal. " +
"\n\nA questão é que você não conseguia tirar os olhos daquele Monte de Cartas, ainda que quisesse, uma força sobrenatural pesava seu corpo e até mesmo seu pescoço e faziam uma pressão tal que qualquer tentativa de" +
" se mexer encontrava uma resistência intransponível. Justo quando você acha que seu fim se aproxima, a velha dá uma gargalhada, cristalina e doce, e quando você a olha repara que ela não era tão velha assim.\n\n" +
"Na verdade, estava na flor da idade, seus traços ciganos fortes como os de uma gata selvagem, os olhos bem verdes, deus, como você não reparou naqueles olhos antes? Ela faz um gesto em direção à cadeira à sua frente" +
"e você finalmente nota que ela não está segurando nenhum baralho nas mãos: ele está parado no centro da mesa, e por um segundo lhe parece que seu Monte de Cartas estende-se verticalmente, infinito, até o céu. Perplexo, você faz... o quê?\n\nOs comandos possíveis são:");


            menu = "\n                                ***** LISTA DE COMANDOS *****\n\n" +
                           "Olha - Você decide fitar mais de perto o Monte de Cartas (Baralho).\n" +
                           "Pisca - A carta do topo do monte será mostrada, então jogada na pilha de descarte\n" +
                           "Lembra - A carta no topo da pilha de descarte será colocada no fundo do Monte de cartas\n" +
                           //"OlharDescarte - Pode-se ver toda a pilha de Descarte atual\n" +
                           "Sonha - Pela ordem numérica das cartas e dos naipes: Paus, Copas, Ouros e Espadas.\n" +
                           "Sopra - O baralho atual será embaralhado.\n" +
                           "Sai - Encerra o Jogo.\n\n" +
                           "O que você faz?";
            Console.WriteLine(menu);

            MonteDeCartas MeuBaralho = new MonteDeCartas();
            MeuBaralho.BaralhoInicial();
            MonteDeCartas Ordenado = new MonteDeCartas();
            Ordenado.BaralhoInicial2();
            MeuBaralho.Embaralhar();


            while (game)
            {
                resposta = Console.ReadLine();
                if (resposta == "OlhaMonte")
                {
                    MeuBaralho.OlharBaralho();

                    if (olhado != 1)
                    {
                        Console.WriteLine("\n\n^ Cartas Acima." +
                            "\n\n\n                                        Evento!" +
                            "\n\n__________________________________________________________________________________________________" +
                            "\n\n...você observa o Monte. O Monte, de alguma forma, te observa.Atentamente. Com algum desprezo, até." +
                            " Como se tivesse muito mais conteúdo que você. Mas que audácia desse Monte!\n\n" +
                        "Justo quando se decide a enumerar todos as suas conquistas e títulos e fios de cabelo restantes, você sente que o Monte já nem está mais interessado, e olha para algum ponto acima, na Tenda." +
                        "\n\nVocê levanta os olhos, e Vê, e é como se Visse pela Primeira Vez.\n\n" +
                        "                                       ** Monte Olhado com Sucesso! **" +
                        "\n__________________________________________________________________________________________________");
                        olhado = 1;
                    }
                    else
                    {
                        Console.WriteLine("\n\n^ Cartas Acima." +
                            "\n\n\n                                                              Evento!" +
                            "\n\n__________________________________________________________________________________________________" +
                            "\n\n ...as cartas agora parecem fazer acrobacias, mudando de cores e de texturas, até desaparecerem num poente impossível." +
                            "\n\nVocê olha ao redor, mas ainda está dentro da Tenda." +
                            " Acima, agora, só a Escuridão.\n\n" +
                        "                                       ** Monte Olhado novamente com Sucesso! **" +
                        "\n__________________________________________________________________________________________________");
                        merito++;
                    }
                    Console.WriteLine(menu);
                }

                else if (resposta == "Pisca")
                {

                    if (descartado != 1)
                    {
                        Console.WriteLine("\n\n\n                                             Evento!" +
                            "\n\n__________________________________________________________________________________________________" +
                            "\n\n ...você pisca os olhos, e nota que a carta do topo do monte agora está sobre a mesa. " +
                            "\n\nVocê lança uma olhadela suspeita em direção à Cigana, mas ela não se mexeu - e suas mãos ainda estão sob o robe...\n\n" +
                        "                                       ** Carta Descartada com Sucesso! **\n__________________________________________________________________________________________________");
                        descartado = 1;
                    }
                    else
                    {
                        Console.WriteLine("\n\n\n                                             Evento!" +
                            "\n\n__________________________________________________________________________________________________" +
                            "\n\n ...você pisca de novo, e voilà, uma nova carta aberta em cima da última. " +
                            "\n\nVocê não tem idéia de como, mas conscientemente decide fingir que é um truque, e não o impressiona mais." +
                            "\n\n'Simples', você diz, com voz entediada, enquanto finge bocejar." +
                            "A cigana não diz nada, mas você não consegue evitar a sensação de que ela ri, sob o véu.\n\n" +
                        "                                      ** Carta Descartada Novamente com Sucesso! **\n__________________________________________________________________________________________________");
                        merito++;
                    }

                    MeuBaralho.Descarte();
                    Console.WriteLine(menu);
                }

                else if (resposta == "Lembra")
                {                    
                    Console.WriteLine("\n\n\n                                                  Evento!" +
                            "\n\n__________________________________________________________________________________________________" +
                        "\n\n...você fecha os olhos se lembra de um passado que nunca existiu: nuvens de algodão-doce desfilam, destacadas sob o céu púrpura, sobre um campo de flores de papel... quando volta a si, você nota que a carta do topo da pilha de Descarte mudou: a última desapareceu. " +
                        "\n\nVocê checa e nota que ela está lááááá no fundinho do Monte de Cartas.\n\n" +
                        "                                      ** Carta Escondida com Sucesso! **\n__________________________________________________________________________________________________");
                    Console.WriteLine(menu);
                }

                else if (resposta == "OlhaDescarte")
                {
                    Console.WriteLine("\nEm implementação - Não deu tempo, mas não estava pedindo na Sintese tb.\n");
                    Console.WriteLine(menu);
                }
                else if (resposta == "Sonha")
                {

                    if (ordenador <= 0)
                    {
                        Ordenado.Ordenar();

                        Console.WriteLine("\n\n\n                                               Evento!" +
                                "\n\n__________________________________________________________________________________________________" +
                            "\n\n ...você está sonhando.E você sonha que o Monte de Cartas subitamente está organizado. Ele NUNCA está organizado.\n" +
                            "Mas aí você lembra que é só um sonho, e admira o Monte organizado, que parece algo... vivo? Poderoso.\n" +
                            "\nE o que é isso que você quase ouve, lá no fundo do fundo...? Seria música?\n\n" +
                            "                                      ** Monte Organizado com Sucesso! **\n__________________________________________________________________________________________________");
                        ordenador = 1;
                    }
                    else if (ordenador > 0 && ordenador < 2)
                    {
                        Ordenado.Ordenar();

                        Console.WriteLine("\n\n\n                                             Evento!" +
                        "\n\n__________________________________________________________________________________________________" +
                        "\n\n ...você sonha que sonha. E dentro desse novo sonho, você dorme, mergulhando cada vez em suas profundezas..." +
                        "...E cada nível é um novo mundo, e cada mundo é seu. Cada segundo lá fora são anos aqui dentro. Mas você não liga, pois sonha, e sonhar é bom...\n\n" +
                        "Um dia, você vê uma tenda de cigana, e algo parece se mexer dentro de si, algo esquecido, quase morto... você se aproxima da tenda, e repara que seu coração acelera.\n\n" +
                        "Você nem se lembra mais da última vez que isso acontecera. Respirando fundo, você afasta o tecido da porta da tenda e entra. A cigana não está.\n" +
                        "Em cima da mesa, o Monte de Cartas te olha, zangado.\n\n " +
                        "Mas como pode um Monte de Cartas fitar, sem olhos? E como sabe que está zangado?" +
                        "Você quase consegue ouvi-lo dizer algo, algo muito distante, como \"Desceu fundo demais. Quase não consegui te fisgar, moleque.\"" +
                        "\n\nSubitamente você acorda. O que houve? Onde você está?\n\n A cigana lhe oferece um chá, e diz:\n\n" +
                        "\"Cochilar por aqui é perigoso, não há nada que segure o espírito que queira subir ou descer. E todos querem, mesmo que não saibam disso..\"" +
                        "- ela dá uma risada e olha para a mesa. Mais precisamente, para o Baralho - Por sorte, temos Ele para resgatar os que se perdem... nem todos, porém... nem todos.\"" +
                        "- seus olhos fitam a distância infinita de seu passado. O Monte de cartas fica parado, mas você poderia jurar que nessa hora ele parecia quase... tímido? Você volta à cadeira e se senta, em silêncio.\n\n" +
                        "                                      ** Monte Organizado Novamente com Sucesso! **\n__________________________________________________________________________________________________");
                        ordenador = 2;
                        merito++;
                        merito++;
                    }
                    else if (ordenador > 1)
                    {
                        Console.WriteLine("\n\n\n                                               Evento!" +
                                "\n\n__________________________________________________________________________________________________" +
                            "\n\n...não importa o que você faça ou tente, você não consegue fazer com que o Monte apareça para você organizado como das outras vezes.\n\n" +
                            "Você sabiamente decide não tentar mais quando o Monte, levemente chateado, quase faz seu coração parar.\n\n" +
                        "                                      ** Monte não organizado: Sem Sucesso! **\n__________________________________________________________________________________________________");
                        merito--;
                    }

                    Console.WriteLine(menu);
                }
                else if (resposta == "Sopra")
                {
                    MeuBaralho.Embaralhar();

                    if (embaralhado != 1)
                    {
                        Console.WriteLine("\n\n\n                                               Evento!" +
                                "\n\n__________________________________________________________________________________________________" +
                    "\n\n...você sopra o Monte de Cartas, como se fosse um bolo de Aniversário, e vê com fascínio as cartas do Monte magicamente se empilhando e desempilhando, como numa dança ancestral.\n\n" +
                        "É um espetáculo ao mesmo tempo violentamente caótico e singularmente belo, e com reverência você assiste calado." +
                        "Quando termina, você de alguma forma entende que no dia seguinte não conseguirá mais recordar do que viu, mas não liga.\n\n" +
                        "(Vi)Ver uma vez já é privilégio suficiente.\n\n" +
                        "                                      ** Monte de Cartas Embaralhado com Sucesso! **\n__________________________________________________________________________________________________");
                        embaralhado = 1;
                    }
                    else
                    {
                        Console.WriteLine("\n\n\n                                               Evento!" +
                                "\n\n__________________________________________________________________________________________________" +
                    "\n\n...você tenta soprar o Monte de Cartas novamente (não sem algum algum receio). Ao soprar, você sente como se rodopiasse, arrastado por ventos de um furacão.\n\n Num momento, você perde sua bússola interna, no outro, seu estômago declara sua independência de você (num golpe nauseante) e, no terceiro, zonzo, " +
                    "você repara que quase caiu da cadeira. \n\nO Monte está embaralhado, e você... também?\n\n" +
                        "                                      ** Monte de Cartas Embaralhado Novamente com Sucesso!** \n__________________________________________________________________________________________________");
                        merito++;
                    }

                    Console.WriteLine(menu);
                }
                else if (resposta == "Sai")
                {
                    if (merito > 3)
                    {
                        Console.WriteLine("\n\n_______________________________________________\n\n...as cartas se foram, a cigana se foi. A tenda está vazia, mas você não se importa, porque ela sempre esteve vazia: seu coração quem a povoava. " +
                            "Você permanece imóvel e silencioso um minuto, relembrando-os com ternura: todos os seus pensamentos, bons e maus. Afasta a entrada da tenda, que também não mais existe." +
                            " E sem seus pensamentos lhe distraindo, você consegue Ver, finalmente, e sorri. Voltar a seu mundo é fácil, mas você experimentou coisas que poucos seres experimentaram antes, e você consegue enxergar muito além. O mundo o qual deixou lhe parece sem graça, mas há uma luz que lhe atrai ao longe, uma sinfonia... para Oeste, então, caminhar de volta à fonte, à luz das Silmarils. E você não tem pressa. O passo que de início é exatamente o mesmo daquele final, e todos" +
                            " serão igualmente prazerosos...\n\n\n" +
                            "**** FIM DO JOGO ****\n\nObrigado por jogar!!! Você descobriu o final secreto! Mas, caso queira tentar descobrir os outros finais, é só jogar e ser menos curioso!\n\nTrabalho feito como Sintese Geral\nDisciplina: Programação para Jogos II\nProfessor: Fabio Aparecido G. Lubacheski\nAluno: Bruno Neves Oliveira\nMackenzie, 2021/1");
                        game = false;
                    }
                    else if (merito > 1 && merito < 4)
                    {
                        {
                            Console.WriteLine("\n\n_______________________________________________\n\n...um barulho ensurdecedor. Tudo escuro, abafado. Desnorteado, você apalpa o nada, até sentir alguma coisa fria, mexendo loucamente. Alguns momentos de pavor escorrem até que você reconheça o formato: um despertador. O SEU despertador. Tocando! O alarme, droga! A festa da escola!\n\nVocê joga o despertador pela janela e se arruma correndo. Ao sair do quarto, você lembra que sonhou alguma coisa esquisita hoje, e tenta puxar um fiozinho dele que ainda resta por ali, tentando escapar: mas o apito do ônibus escolar chegando lhe faz decidir que não vale a pena: a vida é muito mais interessante.\n\n\n" +
                                "**** FIM DO JOGO ****\n\nObrigado por jogar!!! Caso queira tentar descobrir os outros finais, é só jogar de novo!\n\nTrabalho feito como Sintese Geral\nDisciplina: Programação para Jogos II\nProfessor: Fabio Aparecido G. Lubacheski\nAluno: Bruno Neves Oliveira\nMackenzie, 2021/1");
                            game = false;
                        }
                    }
                    else if (merito < 2)
                    {
                        Console.WriteLine("\n\n_______________________________________________\n\n...quando você sai da tenda, tudo se apaga da mente. Quem é você mesmo? Ah, e o que importa? Enquanto os séculos passam, cada dia será sentido como novo em folha, mesmo sendo todos iguais, pois aqui o Amanhã não leva o Ontem à tiracolo. Uma benção, e uma maldição. \n\nVocê continuará perambulando eternamente nessa Terra Encantada, ou pelo menos até que a Tenda e o Baralho lhe ofereçam uma nova oportunidade. Eles estão por aí, é só procurar. \n\nBem de vez em quando, você chega a ter a impressão que esqueceu algo muito importante, mas nunca se lembra o quê...\n\n\n" +
                            "**** FIM DO JOGO ****\n\nObrigado por jogar!!! Caso queira tentar descobrir os outros finais, jogue novamente!\n\nTrabalho feito como Sintese Geral\nDisciplina: Programação para Jogos II\nProfessor: Fabio Aparecido G. Lubacheski\nAluno: Bruno Neves Oliveira\nMackenzie, 2021/1");
                        game = false;
                    }


                }
                else
                {
                    if (errou != 1)
                    {
                        Console.WriteLine("\n\n...você pigarreia, e a Cigana lhe oferece um chá. Não exija demais de si mesmo, recomenda ela, suas voz suave e materna. O feitiço se quebra de repente ao notar que o Monte zomba de sua competência, " +
                        "como se voc6e de alguma forma tivesse superado negativamente as expectativas já nulas que o Monte nutria de si." +
                        "       ** Comando não identificado, favor digitar novamente... **");
                        errou = 1;
                        merito--;
                    }
                    else
                    {
                        Console.WriteLine("\n\n...você tenta falar com a Cigana, mas subitamente começa a gaguejar terrivelmente ao perceber que Ela o fita. " +
                            "O Monte de Cartas, ao fundo, silenciosamente gargalha loucamente, e você se pergunta porque foi mesmo que se levantou da cama hoje..." +
                        "       ** Comando novamente não identificado, favor ler a Lista de Comandos. Sim, as Maiúsculas importam. **");
                        merito--;
                    }

                    Console.WriteLine(menu);
                }
            }
        }
    }
}