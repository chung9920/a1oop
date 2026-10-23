"""Run with: python3 -I C/Tests/test_structured.py"""

import os
from pathlib import Path
import shlex
import subprocess
import tempfile


ROOT = Path(__file__).resolve().parents[1]


def run(program, text):
    return subprocess.run(
        [str(program)], input=text, text=True, capture_output=True, timeout=5, check=True
    ).stdout


def check(program):
    output = run(program, "4\n1\nAlice Nguyen\n30\nEngineer\n1\nBob Tran\n41\nTester\n4\n3\nAlice Nguyen\n2\nAlice Nguyen\n3\nAlice Nguyen\n3\nBob Tran\n2\nBob Tran\n2\nMissing\n4\n5\n")
    assert output.count("No employees available.") == 2, output
    assert output.count("Alice Nguyen, Age: 30, Position: Engineer") == 2, output
    assert output.count("Bob Tran, Age: 41, Position: Tester") == 2, output
    assert output.count("Employee added.") == 2, output
    assert output.count("Employee removed.") == 2, output
    assert output.count("Employee not found.") == 2, output

    output = run(program, "invalid\n1\n \n Alice \nno\n0\n-1\n2147483648\n9999999999999999999999999\n30x\n30\n \n Engineer \n3\n Alice \n5\n")
    assert "Invalid choice." in output, output
    assert output.count("Value cannot be empty.") == 2, output
    assert output.count("Age must be a positive whole number.") == 6, output
    assert "Alice, Age: 30, Position: Engineer" in output, output

    output = run(program, "1\n" + "x" * 1000 + "\nAlice\n30\nEngineer\n3\nAlice\n5\n")
    assert "Input is too long." in output, output
    assert output.count("Employee added.") == 1, output
    assert "Alice, Age: 30, Position: Engineer" in output, output

    output = run(program, "1\nAlice\n30\nEngineer\n1\nAlice\n40\nTester\n2\nAlice\n3\nAlice\n5\n")
    assert "Alice, Age: 40, Position: Tester" in output, output

    # EOF must terminate at every prompt without adding a partial employee.
    for text in ("", "1\n", "1\nAlice\n", "1\nAlice\n30\n", "2\n", "3\n"):
        assert "Employee added." not in run(program, text)
    output = run(program, "1\nAlice\n30\nEngineer\n4")
    assert "Alice, Age: 30, Position: Engineer" in output, output

    # Growing the collection must preserve earlier records.
    text = "".join(f"1\nEmployee {i}\n30\nEngineer\n" for i in range(150))
    output = run(program, text + "3\nEmployee 0\n3\nEmployee 149\n5\n")
    assert output.count("Employee added.") == 150, output
    assert "Employee 0, Age: 30, Position: Engineer" in output, output
    assert "Employee 149, Age: 30, Position: Engineer" in output, output


with tempfile.TemporaryDirectory(prefix="employee-manager-tests-") as directory:
    program = Path(directory) / "employee-manager"
    source = ROOT / "EmployeeManager.c"
    assert source.is_file(), "C structured EmployeeManager is missing"
    subprocess.run(
        shlex.split(os.environ.get("CC", "cc"))
        + ["-std=c11", "-Wall", "-Wextra", "-Werror", "-pedantic"]
        + shlex.split(os.environ.get("CFLAGS", ""))
        + [str(source), "-o", str(program)],
        check=True,
    )
    check(program)

print("PASS")
