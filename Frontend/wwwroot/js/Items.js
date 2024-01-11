$(document).ready(function () {
  table = $("#tb_items").DataTable({
    ajax: {
      url: "https://localhost:7269/api/Items",
      type: "GET",
      datatype: "json",
      dataSrc: "allData",
    },
    columns: [
      {
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1 ;
        }
      },
      {
        data: "name"
      },
      {
        data: "quantity"
      },
      {
        data: "price"
      },
      {
        // Menambahkan kolom "Action" berisi tombol "Edit" dan "Delete" dengan Bootstrap
        data: null,
        render: function (data, type, row) {
            var editButton =
                '<button class="btn btn-warning" data-placement="left" data-toggle="modal" data-animation="false" title="Edit" onclick="return GetById(' +
                row.id +
                ')"><i class="fa fa-edit"></i></button>';

            var deleteButton =
                '<button class="btn btn-danger" data-placement="right" data-toggle="modal" data-animation="false" title="Delete" onclick="return Delete(' +
                row.id +
                ')"><i class="fa fa-trash"></i></button>';

            return (
                '<div class="d-flex">' +
                editButton +
                "&nbsp;" +
                deleteButton +
                "</div>"
            );
      },
      }
    ]
  })
})
  function SaveItem() {
    var isValid = true;

    var isValid = true;
    $("input[required]").each(function () {
      var input = $(this);
      if (!input.val()) {
          input.next(".error-message").show();
          isValid = false;
      } else {
          input.next(".error-message").hide();
      }
    });
    if (!isValid) {
      return;
    }
    var Items = new Object()
    Items.name = $("#ItemName").val()
    Items.quantity = $("#ItemQuantity").val()
    Items.price = $("#ItemPrice").val()
    $.ajax({
      type: "POST",
      url: "https://localhost:7269/api/Items",
      data: JSON.stringify(Items),
      contentType: "application/json; charset=utf-8",
    }).then((result) => {
      if (
        (result.status == result.status) == 201 ||
        result.status == 204 ||
        result.status == 200
    ) {
        Swal.fire({
            icon: "success",
            title: "Success...",
            text: "Data has been added!",
            showConfirmButton: false,
            timer: 1500,
        });
        $("#ModalItem").modal("hide");
        table.ajax.reload();
    } else {
        Swal.fire({
            icon: "warning",
            title: "Data failed to added!",
            showConfirmButtom: false,
            timer: 1500,
        });
        $("#ModalItem").modal("hide");
        table.ajax.reload();
    }
    })
  }

function GetById(ItemId){
  $.ajax({
    url: "https://localhost:7269/api/Items/" + ItemId,
    type: "GET",
    datatype: "json",
    success: function(result){
      var obj = result.get
      $("#ItemId").val(obj.id)
      $("#ItemName").val(obj.name)
      $("#ItemQuantity").val(obj.quantity)
      $("#ItemPrice").val(obj.price)
      $("#ModalItem").modal("show");
      $("#Save").hide();
      $("#Update").show();
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
  },
  })
}

function UpdateItem(){
  var isValid = true;

    $("input[required]").each(function () {
        var input = $(this);
        if (!input.val()) {
            input.next(".error-message").show();
            isValid = false;
        } else {
            input.next(".error-message").hide();
        }
    });
    if (!isValid) {
      return;
    }
    var Items = new Object()
    Items.id = $("#ItemId").val()
    Items.name = $("#ItemName").val()
    Items.quantity = $("#ItemQuantity").val()
    Items.price = $("#ItemPrice").val()
    $.ajax({
      url: "https://localhost:7269/api/Items/" + ItemId,
      type: "PUT",
      data: JSON.stringify(Items),
      contentType: "application/json; charset=utf-8",
    }).then((result) => {
      if (result.status == 200) {
          Swal.fire({
              icon: "success",
              title: "Success...",
              text: "Data has been update!",
              showConfirmButton: false,
              timer: 1500,
          });
          $("#ModalItem").modal("hide");
          table.ajax.reload();
      } else {
          Swal.fire("Error!", "Data failed to update!", "error");
          table.ajax.reload();
      }
  });
}

function Delete(ItemId) {
  Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      type: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!",
      cancelButtonText: "No",
  }).then((result) => {
      if (result.value) {
          $.ajax({
              url: "https://localhost:7269/api/Items/" + ItemId,
              type: "DELETE",
              dataType: "json",
          }).then((result) => {
              // debugger;
              if (result.status == 200) {
                  Swal.fire("Deleted!", "Item Deleted.", "success");
                  table.ajax.reload();
              } else {
                  Swal.fire("Error!", "Failed to delete.", "error");
              }
          });
      }
  });
}

function ClearModalItem(){
  $("#ItemName").val("");
  $("#ItemQuantity").val("");
  $("#ItemPrice").val("");
  $("#Update").hide();
  $("#Save").show();
  $("input[required]").each(function () {
    var input = $(this);
    input.next(".error-message").hide();
});
}

