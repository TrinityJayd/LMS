
const infoButton = document.getElementById('info');

// Initialize the popover instance
var popoverInstance = null;

// Track visibility
var popoverVisible = true;

let gameInProgress = false;

const selectElement = document.getElementById('level-select');

const startButton = document.getElementById('start-btn');
startButton.hidden = true;

selectElement.addEventListener('change', function () {
    if (selectElement.value == "Beginner") {
        startButton.hidden = true;
    } else {
        startButton.hidden = false;
    }
});


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


const submitButton = document.getElementById('check-submit-button');
const resultMod = document.getElementById('result-modal');
const modalTitle = document.getElementById('outcome');

// Attach the handleSubmit function to the submit button's click event
submitButton.addEventListener('click', handleSubmit);

function handleSubmit() {
    if (gameInProgress) {
        // Stop the timer if the game is in progress
        clearInterval(ticker);
        gameInProgress = false;
    }

    // Get the sorted order of the items
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
                        const bsModal = new bootstrap.Modal(resultMod);

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


//Code Attribution
//Link: https://codepen.io/gulzaib/pen/PoKVmNw
//Author: Gulzaib

var timeInSecs;
var ticker;

const timer = document.getElementById('timer-container');
timer.hidden = true;

function startTimer(secs) {
    timeInSecs = parseInt(secs);
    ticker = setInterval("tick()", 1000);
    startButton.hidden = true;
    timer.hidden = false;
    gameInProgress = true;
}

function tick() {
    var secs = timeInSecs;
    if (secs > 0) {
        timeInSecs--;
    } else {
        startButton.hidden = false;
        clearInterval(ticker);

        timer.hidden = true;

        gameInProgress = false;


        handleSubmit();
    }

    var mins = Math.floor(secs / 60);
    secs %= 60;

    var formatSeconds = ((secs < 10) ? "0" : "") + secs;

    timer.innerHTML = formatSeconds;
}



startButton.addEventListener('click', () => {
    var level = selectElement.value;
    if (level == "Intermediate") {
        startTimer(35);
        timer.innerHTML = "35";
    }
    else if (level == "Challenger") {
        startTimer(30);
        timer.innerHTML = "30";

    }
    else if (level == "Expert") {
        startTimer(5);
        timer.innerHTML = "25";
    }

});


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
