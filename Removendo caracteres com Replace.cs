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