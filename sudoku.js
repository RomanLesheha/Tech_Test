function ifContainAllNumber(list) {
    let contain = [...Array(9).keys()].map(x => x + 1).every(x => list.includes(x));
    return contain;
  }
  
  function checkGrid3x3(grid) {
    for (let i = 0; i < grid.length; i += 3) {
      for (let j = 0; j < grid[0].length; j += 3) {
        let subGrid = [];
        for (let k = i; k < i + 3; k++) {
          for (let m = j; m < j + 3; m++) {
            subGrid.push(grid[k][m]);
          }
        }
        if (!ifContainAllNumber(subGrid)) {
          return false;
        }
        subGrid = [];
      }
    }
    return true;
  }
  
  function checkRowsColumns(grid) {
    let tempColumns = [];
    let tempRows = [];
    for (let i = 0; i < grid.length; i++) {
      for (let j = 0; j < grid[0].length; j++) {
        tempRows.push(grid[i][j]);
        tempColumns.push(grid[j][i]);
      }
      if (!ifContainAllNumber(tempRows) || !ifContainAllNumber(tempColumns)) {
        return false;
      }
      tempRows = [];
      tempColumns = [];
    }
    return true;
  }
  
  function sudoku(grid) {
    if (checkRowsColumns(grid) || checkGrid3x3(grid)) {
      return true;
    }
    return false;
  }
  
  let grid = [  [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
  ];
  
  console.log(sudoku(grid));