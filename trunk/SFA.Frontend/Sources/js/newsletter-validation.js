$(document).ready(function () {

    setTimeout(function () {
        console.log('launch');
        $("#launch_modal").click();
    }, 10000);

    $('#send_newsletter').click(function (e) {

        $('#send_newsletter').disabled = true;
        $('#nl_email').disabled = true;
        $('#nl_name').disabled = true;
        //Stop form submission & check the validation
        e.preventDefault();
        console.log($('#nl_email').val());
        console.log($('#nl_name').val());

        // Variable declaration
        var error = false;
        var ccr_email = $('#nl_email').val();

        // Form field validation

        if (ccr_email.length == 0 || ccr_email.indexOf('@') == '-1') {
            var error = true;
            $('#nl_mail_fail').fadeIn(500);
        } else {
            $('#nl_mail_fail').fadeOut(500);
        }

        // If there is no validation error, next to process the mail function
        if (error == false) {
            // Disable submit button just after the form processed 1st time successfully.
            $('#send_message').attr({ 'disabled': 'true', 'value': 'Sending...' });

            /* Post Ajax function of jQuery to get all the data from the submission of the form as soon as the form sends the values to email.php*/
            //$.post("email.php", $("#contact-form").serialize(),function(result){
            $.post("/umbraco/api/Newsletter/Subscribe/", $("#newsletter-form").serialize(), function (result) {
                //Check the result set from email.php file.
                if (result == 'sent') {
                    //If the email is sent successfully, remove the submit button



                    //Display the success message
                    $('#nl_mail_success').fadeIn(1000);

                    setTimeout(function () {
                        $('#myModalHorizontal').modal('hide')
                    }, 3000);
                } else {

                    $('#send_newsletter').disabled = false;
                    $('#nl_email').disabled = false;
                    $('#nl_name').disabled = false;
                    //Display the error message
                    $('#nl_mail_fail').fadeIn(500);
                    // Enable the submit button again
                    $('#send_message').removeAttr('disabled').attr('value', 'Send The Message');
                }
            });
        }
    });
});