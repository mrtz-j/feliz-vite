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
  fable = pkgs.buildDotnetGlobalTool (finalAttrs: {
    pname = "fable";
    version = "5.0.0-alpha.15 ";
    nugetHash = "sha256-8NeMcGqwZW5z/YUbNXHIsCBrPQ92cp/Uki/pIpKLMVo=";
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
      dotnetCorePackages.sdk_10_0
      fantomas
      fsautocomplete
    ];
  };
}
