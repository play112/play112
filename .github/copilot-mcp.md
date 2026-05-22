# MCP Servers Configuration for play112

This document describes the Model Context Protocol (MCP) servers available for this project.

## Filesystem MCP Server

The filesystem server provides safe file operations and directory navigation capabilities.

### Capabilities
- Browse project structure
- Read project files (source code, configuration, documentation)
- Search for files by name patterns
- Understand file hierarchy and dependencies

### Usage in Copilot Sessions
When asking Copilot about project structure, file locations, or file contents, it can use this MCP server to efficiently explore the codebase without requiring manual tool calls.

### Typical Use Cases
- "Show me all test files"
- "Where are the Entity definitions?"
- "What files depend on ILoanRepository?"
- "Find all error handling in the application"

## Future MCP Servers

Consider adding:
- **dotnet-symbols**: For C# symbol resolution and cross-project dependency analysis
- **git-repository**: For commit history and change tracking
- **build-tools**: For compilation diagnostics and build output analysis
