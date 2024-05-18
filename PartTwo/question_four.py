import matplotlib.pyplot as plt
import numpy as np
import scipy.stats


def get_input() -> None:
    user_input = ""
    numbers = []
    while user_input != "-1":
        user_input = input("Please enter a number: ").strip()
        if user_input != "-1":
            numbers.append(float(user_input))
    print("Average: ", average(numbers))
    print("Amount of positive numbers: ", positive_numbers(numbers))
    print(sort_numbers(numbers))
    numbers_graph(numbers)


def average(numbers_list: list) -> float:
    sum = 0
    for number in numbers_list:
        sum += number
    return sum / len(numbers_list)


def positive_numbers(numbers_list: list) -> int:
    counter = 0
    for number in numbers_list:
        if number > 0:
            counter += 1
    return counter


def sort_numbers(numbers_list: list) -> list:
    return sorted(numbers_list)


def numbers_graph(numbers_list: list) -> None:
    x = np.array([index for index in range(1, len(numbers_list)+1)])
    y = np.array(numbers_list)
    plt.title("Numbers Graph Results")
    plt.xlabel("Number of input")
    plt.ylabel("Number entered")
    result = scipy.stats.linregress(x, y)
    print(f"The rvalue: {result.rvalue}")
    plt.scatter(x, y)
    plt.show()


get_input()
