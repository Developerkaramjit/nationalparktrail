var dataTable;
$(document).ready(function (){
    loadDataTable();
})
function loadDataTable()
{
    dataTable = $('#tblData').dataTable
    ({
        "ajax":
        {
            "url": "Trail/GetAllTrails",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "nationalPark.name", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "distance", "width": "20%" },
            { "data": "elevation", "width": "20%" },
            {
                "data": "id",
                "render": function (data)
                {
                    return `<div class="text-center">
                  <a class="btn btn-info" href="/Trail/Upsert/${data}"><i class="fas fa-edit"></i></a>
                  <a class="btn btn-danger" onclick=Delete("/Trail/Delete/${data}")><i class="fas fa-trash-alt"></i></a> `
                }

            }
        ]
    })
}
function Delete(url)
{
    swal
    ({
        title: "want to delete data?",
        icon: "warning",
        buttons: true,
        dangerModel: true,
        Text:"Delete Information"
    }).then((willdelete) =>
    {
        if (willdelete)
        {
            $.ajax
           ({
                url: url,
                type: "Delete",
                success: function (data)
                {
                    if (data.success)
                    {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else
                    {
                        toastr.error(data.message)
                    }
                }
           })
        }
    })
}