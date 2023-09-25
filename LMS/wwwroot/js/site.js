
// POPOVER ABOUT THE DIFFERENT LEVELS

const infoButton = document.getElementById('info');
// Initialize the popover instance
var popoverInstance = null;

// Track visibility
var popoverVisible = true;

const selectElement = document.getElementById('level-select');
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

// END


// MAKE THE LIST DRAGGABLE


// Code Attribution
// Link:https://www.w3schools.com/html/html5_draganddrop.asp
// Author: W3Schools

// Get the list element
const list = document.getElementById('sortable-list');
let draggingElement = null;

// Attach the dragstart event listener to the list element
list.addEventListener('dragstart', (e) => {
    draggingElement = e.target;
    e.dataTransfer.setData('text/plain', e.target.textContent);
});

// Attach the dragend event listener to the list element
list.addEventListener('dragover', (e) => {
    e.preventDefault();
});

// Attach the dragenter event listener to the list element
list.addEventListener('dragenter', (e) => {
    const listItem = e.target.closest('li');

    if (listItem && listItem !== draggingElement) {
        const mouseY = e.clientY;
        const boundingBox = listItem.getBoundingClientRect();
        const halfwayPoint = boundingBox.top + boundingBox.height / 2;

        // Determine the position to insert the dragged item
        const insertBefore = mouseY < halfwayPoint;

        if (insertBefore) {
            list.insertBefore(draggingElement, listItem);
        } else {
            list.insertBefore(draggingElement, listItem.nextSibling);
        }
    }
});

list.addEventListener('dragleave', (e) => {
    e.preventDefault();
});

list.addEventListener('drop', (e) => {
    e.preventDefault();
    e.target.classList.remove('over-top-half', 'over-bottom-half');
});

//END


// SUBMIT THE SORTED LIST

const submitButton = document.getElementById('check-submit-button');
// Attach the handleSubmit function to the submit button's click event
submitButton.addEventListener('click', handleSubmit);

// Variable to track if the timer is in running
let gameInProgress = false;

// Function for the check button
function handleSubmit() {
    if (gameInProgress) {
        // Stop the timer if the timer is in running
        clearInterval(ticker);
        gameInProgress = false;
    }

    // Get the user sorted order of the items
    const sortedItems = Array.from(list.children).map(li => li.textContent);

    // Send the sortedItems to the server using a POST request
    fetch('/ReplaceBooks/SubmitSortedItems', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(sortedItems), // Send the array directly, not as an object
    })
        .then(response => {
            if (response.ok) {
                return response.text()
                    .then(result => {
                        const resultMod = document.getElementById('result-modal');
                        const bsModal = new bootstrap.Modal(resultMod);

                        const modalTitle = document.getElementById('outcome');
                        if (result === 'Win') {
                            modalTitle.textContent = 'Congratulations! You Win!';
                        } else if (result === 'Lose') {
                            modalTitle.textContent = 'Oops! You Lose!';
                        }

                        bsModal.show();
                    });
            } else {
                console.error('Error submitting sorted items');
                return Promise.reject('Error submitting sorted items');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

// END


// TIMER FUNCTIONALITY

//Code Attribution
//Link: https://codepen.io/gulzaib/pen/PoKVmNw
//Author: Gulzaib

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
        submitButton.hidden = false;
    } else {
        startButton.hidden = false;
        submitButton.hidden = true;
    }
});


function startTimer(secs) {
    timeInSecs = parseInt(secs);

    // Start the timer
    ticker = setInterval("tick()", 1000);

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

        handleSubmit();
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

    submitButton.hidden = false;

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
