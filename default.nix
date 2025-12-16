{
  sources ? import ./npins,
  system ? builtins.currentSystem,
  pkgs ? import sources.nixpkgs {
    inherit system;
    config = { };
    overlays = [ ];
  },
}:
let
  dotnet-sdk = pkgs.dotnetCorePackages.sdk_10_0;
  fable = pkgs.buildDotnetGlobalTool (finalAttrs: {
    inherit dotnet-sdk;
    pname = "fable";
    version = "5.0.0-alpha.21";
    nugetHash = "sha256-p/DE1nwcRmDtBWyDB4zPz3KH8gPOM8zis0+8bzwf8Z4=";
  });
in
{
  shell = pkgs.mkShell {
    packages = with pkgs; [
      # nix
      npins

      # web
      bun
      fable

      # fsharp
      dotnet-sdk
      fantomas
      fsautocomplete
    ];
  };
}
