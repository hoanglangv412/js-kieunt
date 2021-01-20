
  //table
  var table = null;
  $(document).ready(function () {
    //load Datatable
    table = $('#datatable').DataTable({
      columnDefs: [{
        targets: [0, 1, 3, 6], type: "dom-text", render: function (data, type, row, meta) {
          return "<input type='text' value='" + data + "' class='form-control'>";
        }
      },
      {
        targets: [2], render: function (data) {
          return createSelectPosition(data);
        }
      },
      {
        targets: [5], render: function (data) {
          return createSelectOffice(data);
        }
      },
      {
        targets: [4], type: "dom-text", render: function (data, type, row, meta) {
          return "<input type='date' value='" + data + "' class='form-control'>";
        }
      },
      {
        targets: [7], type: "dom-text", render: function (data, type, row, meta) {
          return "<input type='button' value='Delete' id='btndelete' class='btn btn-danger'/>";
        }
      },
      ],
      searching: false,
      paging: false,
      "data": dataJson.users,
      "columns": [
        { "data": "id" },
        { "data": "name" },
        { "data": "position" },
        { "data": "salary" },
        { "data": "start_date" },
        { "data": "office" },
        { "data": "extn" },
        { "data": "null" }
      ]
    });
    //End load Datatable

    //select row to detail
    $('#datatable').on('click', 'tr', function () {
      if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
      } else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        var data = table.row(this).data();
        $(".name").val(data.id);
        $(".pos").val(data.position);
        $(".salary").val(data.salary);
        $(".date").val(data.start_date);
        $(".office").val(data.office);
        $(".extn").val(data.extn);
      }
    });
  });

  //delete
  $("#datatable").on("click", "#btndelete", function () {
    $(this).closest("tr").remove();
  });
  //enddelete

  //save function
  function saveFunction() {
    var data = table.rows().data();
    console.log(data);
  }
  //end save function

  //combobox position function
  function createSelectPosition(selItem) {
    var sel = "<select class='form-control'>";
    $.each(dataJson.positions, function () {
      if (this.id == selItem) {
        sel += "<option selected value = '" + this.id + "' >" + this.name + "</option>";
      }
      else sel += "<option  value = '" + this.id + "' >" + this.name + "</option>";
    });
    sel += "</select>";
    return sel;
  }
  //end combobox position function

  //combobox office function
  function createSelectOffice(selItem) {
    var sel = "<select class='form-control'>";
    $.each(dataJson.offices, function () {
      if (this.id == selItem) {
        sel += "<option selected value = '" + this.id + "' >" + this.name + "</option>";
      }
      else sel += "<option  value = '" + this.id + "' >" + this.name + "</option>";
    });
    sel += "</select>";
    return sel;
  }
  //end combobox office function


  // function clear
  function clearFunction() {
    location.reload();
  }
  //end function clear

  //search function
  function searchFunction() {
    var valueId = $('#id').val();
    var valueName = $('#name').val();
    $('#datatable tbody tr').each(function () {
      var found = 'false';
      if ((valueId.length > 0) && (valueName.length > 0)) {
        if (($(this).find("td:nth-child(2)").html().toLowerCase().indexOf(valueName.toLowerCase()) >= 0)
          && ($(this).find("td:first-child").html().indexOf(valueId) >= 0)) {
          found = 'true';
        }
      }
      else if ((valueId.length == 0) && (valueName.length > 0)) {
        if (($(this).find("td:nth-child(2)").html().toLowerCase().indexOf(valueName.toLowerCase()) >= 0)) {
          found = 'true';
        }
      }
      else if ((valueId.length > 0) && (valueName.length == 0)) {
        if ($(this).find("td:first-child").html().indexOf(valueId) > 0) {
          found = 'true';
        }
      }
      if (found == 'true') {
        $(this).show();
      }
      else {
        $(this).hide();
      }
    })
  }
  //end search function