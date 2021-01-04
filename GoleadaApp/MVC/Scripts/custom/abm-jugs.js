$("#add").click(function () {

    var lastid = $(".form-jug:last").attr("id");
    var split_id = lastid.split("_");
    var nextindex = Number(split_id[1]) + 1;

    var total_elements = $(".form-jug").length;
    var max = 5;
    if (total_elements < max) {
        var $div = $("#tem-form-jug").html();
        $("#form-mov").append($div);

        var $div = $("#form_tem");
        $("#form_tem").find(".btn-jug").attr("id", "remove_" + nextindex);
        $("#form_tem").find(".input-jug").attr("id", "Nombre_" + nextindex);
        $("#form_tem").find(".msg-val").attr("id", "msg_" + nextindex);

        $("form_tem").removeAttr("id");
        $("#form_tem").attr("id", "form_" + nextindex);
    }
});

function remove() {
    $('.form-jug').on('click', '.remove', function () {
        var id = this.id;
        var split_id = id.split("_");
        var deleteindex = split_id[1];
        $("#form_" + deleteindex).remove();
    });
}

function validar() {
    var total = $('.form-jug');
    var error = 0;

    for (var i = 0; i < total.length; i++) {

        var id = total[i].id;
        var split_id = id.split("_");
        var index = split_id[1];
        var input = $("#Nombre_" + index).val();
        var msg = "";

        if (input.length <= 0) {
            msg = "El nombre es requerido";
            error++;
        }
        else if (input.length < 4) {
            msg = "El nombre no puede tener menos de 4 caracteres";
            error++;
        }
        else if (input.length > 80) {
            msg = "El nombre no puede exceder los 80 caracteres";
            error++;
        }
        $("#msg_" + index).html(msg);
    }

    if (error != 0) {
        return false;
    }
    return true;
}

dragula([document.getElementById("form-mov")], {
    moves: function (el, container, handle) {
        return handle.classList.contains('form-jug') ||
            handle.classList.contains('btn-move');
    }
});