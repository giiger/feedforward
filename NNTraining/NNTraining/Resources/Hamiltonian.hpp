//
//  Hamiltonian.hpp
//  NNTraining
//
//  Created by Michael Schuff on 4/10/20.
//  Copyright © 2020 Michael Schuff. All rights reserved.
//

#ifndef Hamiltonian_hpp
#define Hamiltonian_hpp

#include <stdio.h>
#include <vector>
#include <algorithm>
#include <ctime>
#include <cstdlib>
#include "MathFunctions.hpp"

using namespace std;
using namespace MathFunctions;

namespace Hamiltonian {
    vector<vector<Vector2D>> ManhattanCycle(int, int);
    vector<vector<Vector2D>> ManhattanCycleDiagonal(int, int);
};

#endif /* Hamiltonian_hpp */
