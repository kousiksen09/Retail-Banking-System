$(document).ready(function () {
    $('#accountTable').DataTable({
        "processing": true,
        "serverSide": false,
        "filter": true,
       
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
    });
});