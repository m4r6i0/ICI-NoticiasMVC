window.carregarFormulario = function (id = 0) {
    let url = id === 0 ? '/Noticia/Create' : `/Noticia/Edit/${id}`;
    $.get(url, function (data) {
        $('#formContainer').html(data);

        setTimeout(() => {
            $('.select2-tags').select2({
                placeholder: "Selecione uma ou mais tags",
                width: '100%'
            });

            $('.select2-user').select2({
                placeholder: "Selecione o autor da notícia",
                width: '100%'
            });
        }, 50);



        $('#noticiaForm').submit(function (e) {
            e.preventDefault();
            window.enviarFormulario();
        });
    });
};

window.enviarFormulario = function () {
    var formData = $('#noticiaForm').serialize();

    $.post('/Noticia/Save', formData, function () {
        location.reload(); // ou atualizar apenas a lista se quiser
    });
};
