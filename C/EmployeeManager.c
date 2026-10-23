#include <ctype.h>
#include <errno.h>
#include <limits.h>
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/* ponytail: text fields hold 127 bytes; use allocated strings for longer values. */
typedef struct {
    char name[128];
    int age;
    char position[128];
} Employee;

typedef struct {
    Employee *employees;
    size_t count;
    size_t capacity;
} EmployeeManager;

/* Data stays in structs; procedures operate on it separately. */
static bool AddEmployee(EmployeeManager *manager, Employee employee)
{
    if (manager->count == manager->capacity) {
        if (manager->capacity > SIZE_MAX / 2 / sizeof(Employee)) {
            return false;
        }
        size_t capacity = manager->capacity == 0 ? 8 : manager->capacity * 2;
        Employee *employees = realloc(manager->employees, capacity * sizeof(Employee));
        if (employees == NULL) {
            return false;
        }
        manager->employees = employees;
        manager->capacity = capacity;
    }
    manager->employees[manager->count++] = employee;
    return true;
}

static const Employee *SearchEmployee(const EmployeeManager *manager, const char *name)
{
    for (size_t i = 0; i < manager->count; ++i) {
        if (strcmp(manager->employees[i].name, name) == 0) {
            return &manager->employees[i];
        }
    }
    return NULL;
}

static bool RemoveEmployee(EmployeeManager *manager, const char *name)
{
    const Employee *employee = SearchEmployee(manager, name);
    if (employee == NULL) {
        return false;
    }
    size_t index = (size_t)(employee - manager->employees);
    memmove(&manager->employees[index], &manager->employees[index + 1],
            (manager->count - index - 1) * sizeof(Employee));
    --manager->count;
    return true;
}

static void DisplayEmployee(const Employee *employee)
{
    if (employee == NULL) {
        puts("Employee not found.");
        return;
    }
    printf("%s, Age: %d, Position: %s\n", employee->name, employee->age, employee->position);
}

static void DisplayAllEmployees(const EmployeeManager *manager)
{
    if (manager->count == 0) {
        puts("No employees available.");
        return;
    }
    for (size_t i = 0; i < manager->count; ++i) {
        DisplayEmployee(&manager->employees[i]);
    }
}

/* Consume the whole line, rejecting oversized or embedded-NUL input. */
static bool ReadLine(const char *prompt, char *buffer, size_t capacity)
{
    for (;;) {
        fputs(prompt, stdout);
        fflush(stdout);
        size_t length = 0;
        bool tooLong = false;
        bool invalid = false;
        int ch;
        while ((ch = getchar()) != '\n' && ch != EOF) {
            if (ch == '\0') {
                invalid = true;
            }
            if (length < capacity - 1) {
                buffer[length++] = (char)ch;
            } else {
                tooLong = true;
            }
        }
        if (ferror(stdin) || (ch == EOF && length == 0)) {
            return false;
        }
        if (tooLong || invalid) {
            puts(tooLong ? "Input is too long." : "Invalid input.");
            if (ch == EOF) {
                return false;
            }
            continue;
        }
        buffer[length] = '\0';
        while (length > 0 && isspace((unsigned char)buffer[length - 1])) {
            buffer[--length] = '\0';
        }
        size_t start = 0;
        while (isspace((unsigned char)buffer[start])) {
            ++start;
        }
        memmove(buffer, buffer + start, length - start + 1);
        return true;
    }
}

static bool ReadRequiredValue(const char *prompt, char *buffer, size_t capacity)
{
    while (ReadLine(prompt, buffer, capacity)) {
        if (buffer[0] != '\0') {
            return true;
        }
        puts("Value cannot be empty.");
    }
    return false;
}

static bool ReadEmployee(Employee *employee)
{
    if (!ReadRequiredValue("Enter name: ", employee->name, sizeof(employee->name))) {
        return false;
    }
    char input[128];
    for (;;) {
        if (!ReadLine("Enter age: ", input, sizeof(input))) {
            return false;
        }
        char *end;
        errno = 0;
        long age = strtol(input, &end, 10);
        if (errno == 0 && end != input && *end == '\0' && age > 0 && age <= INT_MAX) {
            employee->age = (int)age;
            break;
        }
        puts("Age must be a positive whole number.");
    }
    return ReadRequiredValue("Enter position: ", employee->position, sizeof(employee->position));
}

int main(void)
{
    EmployeeManager manager = {0};
    char input[128];
    int status = EXIT_SUCCESS;

    puts("\n===== STRUCTURED STYLE (C) =====");
    puts("Data: EmployeeManager and Employee structs");
    puts("Procedures: AddEmployee(), SearchEmployee(), RemoveEmployee()");
    for (;;) {
        puts("\n1. Add employee\n2. Remove employee\n3. Search employee\n4. Display all employees\n5. Exit");
        if (!ReadLine("Enter choice: ", input, sizeof(input)) || strcmp(input, "5") == 0) {
            break;
        }
        if (strcmp(input, "1") == 0) {
            Employee employee = {0};
            if (!ReadEmployee(&employee)) {
                break;
            }
            if (!AddEmployee(&manager, employee)) {
                fputs("Unable to allocate memory for employee.\n", stderr);
                status = EXIT_FAILURE;
                break;
            }
            puts("Employee added.");
        } else if (strcmp(input, "2") == 0) {
            if (!ReadLine("Enter employee name to remove: ", input, sizeof(input))) {
                break;
            }
            puts(RemoveEmployee(&manager, input) ? "Employee removed." : "Employee not found.");
        } else if (strcmp(input, "3") == 0) {
            if (!ReadLine("Enter employee name to search: ", input, sizeof(input))) {
                break;
            }
            DisplayEmployee(SearchEmployee(&manager, input));
        } else if (strcmp(input, "4") == 0) {
            DisplayAllEmployees(&manager);
        } else {
            puts("Invalid choice.");
        }
    }

    if (ferror(stdin)) {
        fputs("Unable to read input.\n", stderr);
        status = EXIT_FAILURE;
    }
    free(manager.employees);
    return status;
}
