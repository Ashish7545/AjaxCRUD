$(document).ready(function () {
    ShowCategoryData();
});

//Display
function ShowCategoryData() {
    $.ajax({
        url: '/Category/CategoryList',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, statu, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.displayOrder + '</td>';
                object += '<td>' + item.createdDateTime + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.id + ')">Edit</a> || <a href="#" class="btn btn-danger" onclick="Delete(' + item.id + ')">Delete</a></td>';  
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't get!");
        }
    });
};

//Add
$('#btnAddCategory').click(function () {
    ClearTextBox();
    $('#CategoryModal').modal('show');
    $('#cId').hide();
    $('#AddCategory').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#catHeading').text('Add Category');
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
    
}
function HideModelPopUp() {
    $('#CategoryModal').modal('hide');
}

function ClearTextBox() {
    $('#Name').val('');
    $('#DOrder').val('');
    $('#CategoryId').val('');
}


//Edit
function Edit(id) {
    $.ajax({
        url: '/Category/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#CategoryModal').modal('show');
            $('#cId').show();
            $('#CategoryId').val(response.id);
            $('#Name').val(response.name);
            $('#DOrder').val(response.displayOrder);
            $('#AddCategory').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#catHeading').text('Update Category');
            //$('#addcategory').hide();
            //$('#btnupdate').show();
        },
        error: function () {
            alert('Data Not Found!');
        }
        })
}
function UpdateCategory() {
    var objData = {
        Id: $('#CategoryId').val(),
        Name: $('#Name').val(),
        DisplayOrder: $('#DOrder').val()
    }
    $.ajax({
        url: '/Category/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Updated!');
            ClearTextBox();
            ShowCategoryData();
            HideModelPopUp();
        },
        error: function () {
            alert("Data can't be Updated!");
        }
    });
}


//Delete
function Delete(id) {
    if (confirm('Are you sure, You want to delete this record?')) {
        $.ajax({
            url: '/Category/Delete?id=' + id,
            success: function () {
                alert("Record Deleted!");
                ShowCategoryData();
            },
            error: function () {
                alert("Data can't be deleted!");
            }
        })
    }
}

