//HTML - Botão
<div class="div-erro-botoes">
    <div>
        <span class="img-btn glyphicon glyphicon-subtitles  exp-glyphicon-update"></span>
        <button type="button" class="btn exp-btn" aria-hidden="true" style="margin-right: 5px !important;">Copiar Dados</button>
    </div>
</div>

//Na View em que o botão for ficar, adicionar um Text Area escondido que ficará os dados a serem copiados
<div style="position:fixed; margin-top:-5000px;">
    <textarea id="dsCopyTexto">
        Cnpj: @cnpj
        Alçada: @alcada
        Segmento: @segmento
        Ramo Atividade: @ramoAtividade
        Plataforma: @plataforma
    </textarea>
</div>

//Como pegamos o valor dos campos via ViewBag, criar os campos e popular com as ViewBags que criamos na controller
@{
    string cnpj = ViewBag.cnpj
    string alcada = ViewBag.alcada
    string segmento = ViewBag.segmento
    string ramoAtividade = ViewBag.ramoAtividade
    string plataforma = ViewBag.plataforma
}

//Na controller onde os campos são populados, ver a melhor forma de pegar os valores para cada situção, 
//mas nesse caso pegamos por posição com HtmlDocument por ser um crawler de um e-mail.
HtmlDocument doc = new HtmlDocument() {OptionAutoCloseOnEnd = true, OptionFixNestedTags = true};
doc.LoadHtml(body);
var camposList = doc.DocumentNode.SelectNodes("//td[@class='infos']");
ViewBag.cnpj = camposList[2].InnerText.PadLeft(9, '0');
ViewBag.alcada = camposList[52].InnerText;
ViewBag.segmento = camposList[6].InnerText.Replace(" ", "");
ViewBag.ramoAtividade = camposList[10].InnerText;
ViewBag.plataforma = camposList[47].InnerText.Substring(0, 4);

//Ação do botão copiar dados no JS
$("body").on("click", "#btnCopiarDadosCotacao", function (e) {
    $(document.getElementById('dsCopyTexto')).select();

    if(!document.execCommand('copy'))
        alert("Falha ao copiar os dados!");
    else{
        $.blockUI({ message: "Dados Copiados"});
        setTimeout($.unblockUI, 500);
    }
});

//Caso precise complementar com infos que seja mais fácil pegar pelo JS, como complemento no copiar dados, pode ser feito dessa forma
function adicionarCopiarDadosEmailRede(){
    var texto = $('#dsCopyTexto').val();

    $('#dsCopyTexto').val(
        texto.substring(0, texto.lastIndexOf('\n')) +
        '\n' + 'Codigo Proposta: ' + ($('#spanAssunto')[0].InnerText.length == 49 ? $$('#spanAssunto')[0].InnerText.slice(43) : $('#spanAssunto')[0].InnerText.slice(36)) + '\n' +
        'Remetente: ' + $('#spanRemetente')[0].InnerText + '\n' + 
        'Data Email: ' + $('#spanDataEmail')[0].InnerText + '\n' +
        'Assunto: ' + $('#spanAssunto')[0].InnerText + '\n'
    );
}