$(document).ready(function () {
    bindDatatable();

    $(".dataTables_scroll").addClass("mb-4");
});

function bindDatatable() {
    datatable = $('#tblStudent')
        .DataTable({
            "scrollX": true,
            "autoWidth": false,
            "responsive ": true,
            "sAjaxSource": "/Goles/GetData",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "emptyTable": "No record found.",
                "processing":
                    '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
            },
            "columns": [
                {
                    "data": "Equipo",
                    "render": function (data, type, row, meta) {
                        return '<a href="GolesPruebaApi/' + data + '">' + data + '</a>';
                    },
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "Cantidad",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "NombreJugador",
                    "autoWidth": true,
                    "searchable": true
                },
            ],
            "language": {
                "url": "/Content/Tables/Json/Spanish.json"
            },
        });
}

