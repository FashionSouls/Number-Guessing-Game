
// main
bool gameCheck = true; 

// Get the range
bool firstNumberCheck = false;
int firstNumber = 0;

bool secondNumberCheck = false;
int secondNumber = 0;

Random random = new Random();
bool targetCheck = false;
int target;

int attempts = 3;

void Reset() {
    attempts = 3;
    firstNumberCheck = false;
    secondNumberCheck = false;
    targetCheck = false;
    gameCheck = true;
}

while (gameCheck) {
    while (!firstNumberCheck) {
        Console.WriteLine("Please enter the smallest number of the range:");
        firstNumberCheck = int.TryParse(Console.ReadLine(), out firstNumber);

        if (!firstNumberCheck) {
            Console.WriteLine("Invalid number - try again.");
        }
    }

    while (!secondNumberCheck) {
        Console.WriteLine("Please enter the biggest number of the range:");
        secondNumberCheck = int.TryParse(Console.ReadLine(), out secondNumber);

        if (!secondNumberCheck) {
            Console.WriteLine("Invalid number - try again.");
        }

        if (secondNumber < firstNumber) {
            secondNumberCheck = false;
            Console.WriteLine("Second number is smaller than first number - try again.");
        }
    }

    target = random.Next(firstNumber + 1, secondNumber - 1);

    Console.WriteLine("----------------\nRange selected - please guess the random number in the range between " + firstNumber + " - " + secondNumber);

    while (!targetCheck) {
        int guess = 0;
        Console.WriteLine("----------------\nYou have " + attempts + " attempts left! Please enter a number between " + firstNumber + " and " + secondNumber);
        targetCheck = int.TryParse(Console.ReadLine(), out guess);

        if (!targetCheck) {
            Console.WriteLine("Invalid number - try again.");
        }

        if (guess < firstNumber || guess > secondNumber) {
            targetCheck = false;
            Console.WriteLine("Invalid number - try again.");
        }

        if (guess == target) {
            Console.WriteLine("You got the number! Well done!");
            targetCheck = true;
        } else {
            attempts--;

            if (attempts > 0) {
                targetCheck = false;
                Console.WriteLine("Incorrect.");
            } else {
                targetCheck = true;
                Console.WriteLine("You have no attempts left! You lose!");
            }
        }
    }

    Console.WriteLine("Do you want to play again? (y/n)");
    string answer = Console.ReadLine();
    if (answer.Equals("y")) {
        Reset();
    } else if (answer.Equals("n")) {
        gameCheck = false;
    }
}