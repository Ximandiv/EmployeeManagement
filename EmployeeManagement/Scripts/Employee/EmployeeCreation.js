$(document).ready(function () {
    // Const values to setup min and max values by default
    const MINLENGTHNUM = 3;
    const MAXLENGTHNUM = 25;
    const MAXLENGTHNAME = 50;

    /*
        Validates the form dynamically with rules, messages and 
        submit handler that is fired up upon submission of form
    */
    $("#employeeForm").validate(
        {
            rules: {
                Name: {
                    required: true,
                    minlength: MINLENGTHNUM,
                    maxlength: MAXLENGTHNAME
                },
                Position: {
                    required: true,
                    minlength: MINLENGTHNUM,
                    maxlength: MAXLENGTHNUM
                },
                Office: {
                    required: true,
                    minlength: MINLENGTHNUM,
                    maxlength: MAXLENGTHNUM
                },
                Salary: {
                    required: true,
                    number: true
                }
            },
            messages: {
                Name: {
                    required: "Name is required",
                    minlength: "Name must have at least " + MINLENGTHNUM + "characters",
                    maxlength: "Name must have maximum " + MAXLENGTHNAME + "characters"
                },
                Position: {
                    required: "Position is required",
                    minlength: "Name must have at least" + MAXLENGTHNUM + "characters",
                    maxlength: "Name must have maximum" + MAXLENGTHNUM + "characters"
                },
                Office: {
                    required: "Office is required",
                    minlength: "Office must have at least" + MAXLENGTHNUM + "characters",
                    maxlength: "Office must have maximum" + MAXLENGTHNUM + "characters"
                },
                Salary: {
                    required: "Salary is required",
                    number: "Salary must be a number"
                }
            },
            errorPlacement: function (error, element) {
                var name = element.attr("name");
                error.appendTo($("[data-valmsg-for='" + name + "']"))
            },
            submitHandler: function (form) {
                $.ajax(
                    {
                        url: '/Employee/AddEmployee',
                        type: 'POST',
                        data: $(form).serialize(),
                        success: function (response) {
                            alert(response.message);
                        },
                        error: function (response) {
                            alert(response.message);
                        }
                    }
                )
            }
        }
    )
})