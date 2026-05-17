#include <iostream>
#include <array>

int main()
{
    std::array<int, 5> data = {1, 2, 3, 4, 5};
    int sum = 0;
    for (int i = 0; i < data.size(); ++i)
    {
        sum += data[i];
    }
    std::cout << sum << std::endl;
    return 0;
}