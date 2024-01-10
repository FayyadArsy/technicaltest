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
        data: "items.price"
      },
      {
        // Menambahkan kolom "Action" berisi tombol "Edit" dan "Delete" dengan Bootstrap
        data: null,
        render: function (data, type, row) {
           
            var deleteButton =
                '<button class="btn btn-danger" data-placement="right" data-toggle="modal" data-animation="false" title="Delete" onclick="return Delete(' +
                row.id +
                ')"><i class="fa fa-trash"></i></button>';

            return (
                '<div class="d-flex">' +
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
