import subprocess
import shutil
from pathlib import Path
import json
import binascii


def test_build_and_run(tmp_path):
    # Build the converter
    subprocess.run([
        "dotnet",
        "build",
        "GvasConverter/GvasConverter.csproj",
        "-c",
        "Release",
    ], check=True)

    # Copy sample save to temp directory
    sample = Path("tests/Axle.sav")
    dst = tmp_path / sample.name
    shutil.copy(sample, dst)

    # Run the converter in the temp directory
    repo_root = Path(__file__).resolve().parents[1]
    dll = repo_root / "GvasConverter" / "bin" / "Release" / "net8.0" / "GvasConverter.dll"
    subprocess.run([
        "dotnet",
        str(dll),
        str(dst)
    ], check=True, cwd=tmp_path)

    # Verify output JSON exists
    out_json = dst.with_suffix(dst.suffix + ".json")
    assert out_json.exists()

    content = out_json.read_text()
    if '"MinerName": "Axle"' in content:
        assert '"MinerName": "Axle"' in content
    else:
        data = json.loads(content)
        hexval = data['Properties'][0]['Value']
        decoded = binascii.unhexlify(hexval).decode('latin-1')
        assert 'MinerName' in decoded and 'Axle' in decoded
