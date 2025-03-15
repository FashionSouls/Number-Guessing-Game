
// main
bool gameCheck = true; 

// Get the range
int firstNumber = 0;

bool secondNumberCheck = true;
int secondNumber = 0;

Random random = new Random();
bool targetCheck = false;
int target;

int attempts = 3;

void Reset() {
    attempts = 3;
    secondNumberCheck = true;
    targetCheck = false;
    gameCheck = true;
}

int GetUserInput() {
    int value = 0;
    bool check = true;

    while (check) {
        check = int.TryParse(Console.ReadLine(), out value);

        if (!check) {
            Console.WriteLine("Invalid number - try again.");
        } else {
            return value;
        }
    }

    return value;
}

while (gameCheck) {
    Console.WriteLine("Please enter the smallest number of the range:");
    firstNumber = GetUserInput();

    while (secondNumberCheck) {
        Console.WriteLine("Please enter the biggest number of the range:");
        secondNumber = GetUserInput();

        if (secondNumber < firstNumber) {
            Console.WriteLine("Second number is smaller than first number - try again.");
        } else {
            secondNumberCheck = false;
        }
    }

    target = random.Next(firstNumber + 1, secondNumber - 1);

    Console.WriteLine("----------------\nRange selected - please guess the random number in the range between " + firstNumber + " - " + secondNumber);

    while (!targetCheck) {
        int guess = 0;
        Console.WriteLine("----------------\nYou have " + attempts + " attempts left! Please enter a number between " + firstNumber + " and " + secondNumber);
        guess = GetUserInput();

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