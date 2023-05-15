$(document).ready(function () {
    ShowCategoryData();
});

function ShowCategoryData() {
    $.ajax({
        url: '/Category/CategoryList',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (data, statu, xhr) {
            var object = '';
            $.each(data, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.Id + '</td>';
                object += '<td>' + item.Name + '</td>';
                object += '<td>' + item.DisplayOrder + '</td>';
                object += '<td>' + item.CreatedDateTime + '</td>';
                object += '<td><a href="#" class="btn btn-primary>Edit</a> || <a href="#" class="btn btn-danger>Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't get!");
        }
    });
};


$('#btnAddCategory').click(function () {
    $('#CategoryModal').modal('show');
})

function AddCategory() {

    var objData = {
        Name: $('#Name').val(),
        DisplayOrder: $('#DOrder').val()
    }
    $.ajax({
        url: '/Category/Create',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Saved!');
            ClearTextBox();
            ShowCategoryData();
            HideModelPopUp();
        },
        error: function () {
            alert("Data can't Saved!");
        }
    });
    function HideModelPopUp() {
        $('#CategoryModal').modal('hide');
    }

    function ClearTextBox() {
        $('#Name').val('');
        $('#DOrder').val('');
    }
}