document
  .getElementById("card-form")
  .addEventListener("submit", function (event) {
    event.preventDefault();

    const cardNumber = document.getElementById("card-number").value;
    const resultDiv = document.getElementById("result");

    const validationResponse = validateCardNumber(cardNumber);
    if (validationResponse.isValid) {
      resultDiv.innerHTML = "✔ Valid Card Number";
      resultDiv.className = "result valid";
    } else {
      resultDiv.innerHTML = `✘ Invalid Card Number<br><span class="error-message">${validationResponse.message}</span>`;
      resultDiv.className = "result invalid";
    }
  });

function validateCardNumber(number) {
  let sum = 0;
  let shouldDouble = false;

  if (number.length !== 16 || number.length !== 15) {
    return { isValid: false, message: "Card number must be 16 or 15 digits long." };
  }

  // Start from the right and move left
  for (let i = number.length - 1; i >= 0; i--) {
    let digit = parseInt(number.charAt(i));

    if (isNaN(digit)) {
      return { isValid: false, message: "Card number must contain only digits." };
    }

    if (shouldDouble) {
      digit *= 2;
      if (digit > 9) {
        digit -= 9;
      }
    }

    sum += digit;
    shouldDouble = !shouldDouble;
  }

  // Card is valid if sum is a multiple of 10
  if (sum % 10 === 0) {
    return { isValid: true, message: "" };
  } else {
    return { isValid: false, message: "Card number does not pass the Luhn check." };
  }
}