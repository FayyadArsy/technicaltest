$(document).ready(function() {
  showItemList();
  table = $("#tb_items").DataTable({
    "searching": false,
    "paging": false,
    info: false,
    "ordering": false,
    ajax: {
      url: "https://localhost:7269/api/Cart",
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
        data: "items.name"
      },
      {
        data: "quantity"
      },
      {
        data: null,  
        render: function (data, type, row) {
          var price = parseFloat(row.items.price);
          var quantity = parseInt(row.quantity);
          var result = price * quantity;
          var formattedResult = "Rp. " + result.toFixed(2);

          return formattedResult;
        }
      },
      {
        // Menambahkan kolom "Action" berisi tombol "Edit" dan "Delete" dengan Bootstrap
        data: null,
        render: function (data, type, row) {
            var editButton =
                '<button class="btn btn-warning" data-placement="left" data-toggle="modal" data-animation="false" title="Edit" onclick="return GetById(' +
                row.cartId +
                ')"><i class="fa fa-edit"></i></button>';

            var deleteButton =
                '<button class="btn btn-danger" data-placement="right" data-toggle="modal" data-animation="false" title="Delete" onclick="return Delete(' +
                row.cartId +
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
});

function showItemList() {
  $('#SelectItem')
  $.ajax({
    url: "https://localhost:7269/api/Items",
    type: "GET",
    dataType: "json",
    success: function (result) {
      var list = result.allData; 

      list.forEach(function (item) {
        const option = new Option(
          item.name,  
          item.id,   
          true,
          true
        );
        $('#SelectItem').append(option);
      });

      // Trigger Select2 to refresh
      $('#SelectItem').trigger('change');
    },
    error: function (errormessage) {
      alert(errormessage.responseText);
    },
  });
  
}

function InputCart(){
  var Cart = new Object(); //bikin objek baru
  Cart.itemsId = $("#SelectItem").val();
  Cart.quantity = $("#ItemQty").val();
  Cart.transactionId = "2";
  $.ajax({
    type: "POST",
    url: "https://localhost:7269/api/Cart",
    data: JSON.stringify(Cart),
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
function Delete(CartId) {
  // debugger;
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
              url: "https://localhost:7269/api/Cart/" + CartId,
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

function GetById(CartId){
  $.ajax({
    url: "https://localhost:7269/api/Cart/" + CartId,
    type: "GET",
    datatype: "json",
    success: function(result){
      var obj = result.get
     
      $("#CartId").val(obj.cartId)
      $("#ItemId").val(obj.itemsId)
      $("#ItemQuantity").val(obj.quantity)
      $("#ModalUpdate").modal("show");
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
    Items.cartId = $("#CartId").val()
    Items.itemsId = $("#ItemId").val()
    Items.quantity = $("#ItemQuantity").val()
    Items.items = {}
    console.log(Items)
    $.ajax({
      url: "https://localhost:7269/api/Cart/" + CartId,
      type: "PUT",
      data: JSON.stringify(Items),
      contentType: "application/json; charset=utf-8",
    }).then((result) => {
      // debugger;
      if (result.status == 200) {
          Swal.fire({
              icon: "success",
              title: "Success...",
              text: "Data has been update!",
              showConfirmButton: false,
              timer: 1500,
          });
          $("#ModalUpdate").modal("hide");
          table.ajax.reload();
      } else {
          Swal.fire("Error!", "Data failed to update!", "error");
          table.ajax.reload();
      }
  });
}