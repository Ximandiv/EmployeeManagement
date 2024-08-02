$(document).ready(function () {
    // Grabs hidden input that has the current page
    var page = parseInt($("#currentPage").data('page'), 10)

    // Const values for fixed values
    const INTERVALTIMEMS = 5000;
    const PAGESIZE = 10;

    // Method that requests to server the list of employees paginated
    function loadEmployeeTable(page, pageSize) {
        $.ajax({
            url: '/Employee/GetEmployees',
            type: 'GET',
            data: { page: page, pageSize: pageSize },
            success: function (data) {
                $('#employeeTableContainer').html(data);
            },
            error: function (data) {
                console.log('An error occurred: ' + data)
            }
        });
    }

    // Periodically refresh the table data every 30 seconds
    setInterval(function () {
        loadEmployeeTable(page, PAGESIZE);
    }, INTERVALTIMEMS);

    // Registers to click event on any pagination button to load the table according to page number
    $(document).on('click', '.pagination a', function (event) {
        event.preventDefault();
        page = $(this).data('page');
        loadEmployeeTable(page, PAGESIZE);
    });

    // Registers to click event on delete button to popup an alert to confirm your choice
    $(document).on('click', '.delete-btn', function (event) {
        event.preventDefault();

        // Grabs the id of the entity chosen
        var id = $(this).data('id');

        var url = '/Employee/DeleteEmployee/' + id;

        var confirmation = confirm('Are you sure you want to delete this item?');
        if (confirmation) {
            $.post(url, function (response) {
                loadEmployeeTable();
            }).fail(function () {
                alert('An error occurred while deleting the item.');
            });
        }
    });
});
