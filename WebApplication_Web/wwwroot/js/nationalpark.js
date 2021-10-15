var dataTable;
$(document).ready(function ()
{
    loadDataTable()
})
function loadDataTable()
{
    dataTable = $('#tblData').DataTable
        ({
            "ajax":
            {
                "url": "NationalPark/GetAll",
                "type": "GET",
                "datatype": "json"
            },
            "columns":
           [
                { "data": "name", "width": "40%" },
                { "data": "state", "width": "40%" },
                {
                    "data": "id",
                    "render": function (data)
                    {
                        return `<div class="text-center">
             <a class="btn btn-primary" href="NationalPark/Upsert/${data}">
                           <i class="far fa-edit"></i>  </a>
             <a class="btn btn-danger" href=Delete("NationalPark/Delete/${data}")>
                           <i class="fas fa-trash-alt"></i>    </a>
                            </div>`;
                    }
                }
           ]
    })
}