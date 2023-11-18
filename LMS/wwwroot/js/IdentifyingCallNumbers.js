$(document).ready(function () {
    $('#level2, #level3').hide(); // Initially hide level 2 and level 3 forms

    let gameInProgress = false;

    $('form').submit(function (e) {
        e.preventDefault(); // Prevent default form submission

        // Get the selected value
        var selectedValue = $(this).find('input[name="selectedOption"]:checked').val();
        var level = $(this).data('level');
        var form = this; // Store the form context

        // AJAX call to the Check method
        $.ajax({
            type: 'POST',
            url: 'FindingCallNumbers/Check',
            data: { selectedOption: selectedValue, level: level },
            success: function (result) {
                if (result === true) {
                    if (level != 2) { 
                        $(form).hide();
                        $(form).next('form').show();
                    } else {
                        if (gameInProgress) {
                            // Stop the timer if the timer is in running
                            clearInterval(ticker);
                            gameInProgress = false;
                        }
                        const resultMod = document.getElementById('result-modal');
                        const bsModal = new bootstrap.Modal(resultMod);

                        const modalTitle = document.getElementById('outcome');
                        modalTitle.textContent = 'Congratulations! You Win!';
                        bsModal.show();
                    }
                            
                } else {
                    if (gameInProgress) {
                        // Stop the timer if the timer is in running
                        clearInterval(ticker);
                        gameInProgress = false;
                    }
                    const resultMod = document.getElementById('result-modal');
                    const bsModal = new bootstrap.Modal(resultMod);

                    const modalTitle = document.getElementById('outcome');
                    modalTitle.textContent = 'Oops! You Lose!';
                    bsModal.show();
                }
            }
        });
    });

    const infoButton = document.getElementById('info');
    // Initialize the popover instance
    var popoverInstance = null;

    // Track visibility
    var popoverVisible = true;

    const selectElement = document.getElementById('level-select');

    const levels = {
        Beginner: "Reach the most detail classification.",
        Intermediate: "Reach the most detail classification in 30 seconds.",
        Challenger: "Reach the most detail classification in 20 seconds",
        Expert: "Reach the most detail classification in 15 seconds"
    };

    function updatePopoverContent() {
        // Get the selected value from the select element
        const selectedValue = selectElement.value;
        // Create the popovers content
        const popoverContent = selectedValue + ": " + levels[selectedValue];

        // Update the popover's content 
        infoButton.setAttribute('data-bs-content', popoverContent);

        if (popoverInstance) {
            // Dispose of the existing popover instance
            popoverInstance.dispose();
        }

        // Reinitialize the popover to apply the updated content
        popoverInstance = new bootstrap.Popover(infoButton, {
            container: 'body'
        });

        if (popoverVisible) {
            // If the popover was visible before, hide it
            popoverInstance.hide();
            popoverVisible = false;
        } else {
            // Otherwise, show the popover
            popoverInstance.show();
            popoverVisible = true;
        }

    }

    // Attach the updatePopoverContent function to the info button's click event
    infoButton.addEventListener('click', updatePopoverContent);

    // Call updatePopoverContent to set the content 
    updatePopoverContent();

    document.addEventListener('click', (e) => {
        // Check if the popover is open and the click is outside of the popover and the info button
        if (popoverVisible && e.target !== infoButton && !infoButton.contains(e.target)) {
            popoverInstance.hide();
            popoverVisible = false;
        }
    });


    var timeInSecs;
    var ticker;

    const timer = document.getElementById('timer-container');
    timer.hidden = true;

    const startButton = document.getElementById('start-btn');
    startButton.hidden = true;

    selectElement.addEventListener('change', function () {
        // The beginner level does not use the timer so it can be hidden
        if (selectElement.value == "Beginner") {
            startButton.hidden = true;
        } else {
            startButton.hidden = false;
        }
    });


    function startTimer(secs) {
        timeInSecs = parseInt(secs);

        // Start the timer
        ticker = setInterval(tick, 1000);

        // Hide the start button
        startButton.hidden = true;

        // Show the timer
        timer.hidden = false;

        // The timer is in running
        gameInProgress = true;
    }

    function tick() {
        var secs = timeInSecs;

        // If the timer is running, decrement the time
        if (secs > 0) {
            timeInSecs--;
        } else {
            // Otherwise, stop the timer and submit the sorted list
            startButton.hidden = false;
            clearInterval(ticker);

            timer.hidden = true;

            gameInProgress = false;

            const resultMod = document.getElementById('result-modal');
            const bsModal = new bootstrap.Modal(resultMod);

            const modalTitle = document.getElementById('outcome');
            modalTitle.textContent = 'Oops! You ran out of time!';
            bsModal.show();
        }

        // Format the seconds to display
        var mins = Math.floor(secs / 60);
        secs %= 60;

        var formatSeconds = ((secs < 10) ? "0" : "") + secs;

        timer.innerHTML = formatSeconds;
    }



    startButton.addEventListener('click', () => {
        var level = selectElement.value;

        //Depending on the level the countdown will be different
        if (level == "Intermediate") {
            startTimer(35);
            timer.innerHTML = "35";
        }
        else if (level == "Challenger") {
            startTimer(30);
            timer.innerHTML = "30";

        }
        else if (level == "Expert") {
            startTimer(25);
            timer.innerHTML = "25";
        }

    });

    // END 

    //Close Buttons for Modal

    const modalCloseButton1 = document.getElementById('close-modal1');
    modalCloseButton1.addEventListener('click', () => {
        // Refresh the page when the modal is closed
        location.reload();
    });

    const modalCloseButton2 = document.getElementById('close-modal2');
    modalCloseButton2.addEventListener('click', () => {
        // Refresh the page when the modal is closed
        location.reload();
    });

});