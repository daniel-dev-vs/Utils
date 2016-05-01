$('.imagens').mouseenter(function () {
    $(this).css({ border: '0 solid #F15971' }).animate({
        borderWidth: 4
    }, 200);
}).mouseleave(function () {
    $(this).animate({
        borderWidth: 0
    }, 500);
});
//anima a galeria de doces  -- FIM


$(document).ready(function () {
    $('.modal-trigger').leanModal();
    var imagens = $('.imagens'), id = imagens[0].id, caminho = "";
    $('.imagens').click(function ()
    {
        $caminho = $(this);
        $('#mod').attr('src', $caminho.attr('src'));
    });

    $('#checarTodos').click(function ()
    {
      
        $this = $(this);
        if ($this.is(':checked')) {
            $('.checkD').prop('checked', true);
        } else {
            $('.checkD').prop('checked', false);
        }
    });

    $('.checkD').click(function () {

        $this = $(this);

        $($this).each(function () {
            $item = $(this);
            if ($item.is(':checked')) {
                $('#checarTodos').prop('checked', true);
                return;
            } else {
                $('#checarTodos').prop('checked', false);
                return;
            }

        });                            
    });




    $edicao = $('.edicao');

    $($edicao).each(function () {
            $item = $(this);
            $item.addClass('naoEditar');

        });


    $('#btnEditar').click(function () {

        $($edicao).each(function () {
            $item = $(this);
            $item.removeClass('naoEditar');

        });
    });

    init();
  
  
});

function init() {
    document.querySelector('#file').addEventListener('change', handleFileSelect, false);
    selDiv = document.querySelector("#selectedFiles");
}

function handleFileSelect(e) {

    if (!e.target.files || !window.FileReader) return;

    selDiv.innerHTML = "";
    var i = 0;
    var files = e.target.files;
    var filesArr = Array.prototype.slice.call(files);
    filesArr.forEach(function (f) {

        var f = files[i];
        if (!f.type.match("image.*")) {
            return;
        }

        var reader = new FileReader();
        reader.onload = function (e) {
            var html = "<img  src=\"" + e.target.result + "\" class='imgLoaded' alt=\""+f.name+"\">";
            selDiv.innerHTML += html;
        }
        i++;
        reader.readAsDataURL(f);
    });

}