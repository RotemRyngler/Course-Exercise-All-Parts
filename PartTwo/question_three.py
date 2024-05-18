def is_sorted_palindrome(string: str) -> bool:
    if is_palindrome:
        for i in range((len(string)//2)):
            if string[i] > string[i+1]:
                return False
        return True
    return False


def is_palindrome(string: str) -> bool:
    for i in range(len(string) // 2):
        if string[i] == string[len(string) - 1 - i]:
            return True
    return False


print(is_sorted_palindrome("abcdcba"))
