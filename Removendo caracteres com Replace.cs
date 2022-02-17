//Remover "." ou ";" ou ";" de uma string

string fraseExemplo = "Hoje, eu vou para casa; Mas vamos passear antes."

//Remove a virgula.
fraseExemplo.Replace(",", "");

//Remove o ponto e virgula.
fraseExemplo.Replace(";", "");

//Remove o ponto.
fraseExemplo.Replace(".", "");

//Remover tudo de uma vez.
fraseExemplo.Replace(",", "").Replace(";", "").Replace(".", "");



//Você pode criar um método que faça isso e só chamar quando precisar, para organizar melhor seu código.

public static String RemoverPontoVigula(String str)
{
    str.Replace(",", "").Replace(".", "");
}

//Exemplo de uso
fraseExemplo = RemoverPontoVigula(fraseExemplo);
//A frase ficara: "Hoje eu vou para casa; Mas vamos passear antes"