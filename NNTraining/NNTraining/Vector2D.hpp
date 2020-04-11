//
//  Vector2D.hpp
//  NNTraining
//
//  Created by Michael Schuff on 4/10/20.
//  Copyright © 2020 Michael Schuff. All rights reserved.
//

#ifndef Vector2D_hpp
#define Vector2D_hpp

#include <stdio.h>
#include <cmath>

using namespace std;

class Vector2D {
public:
    float x, y;
    double theta, magnitude;
    
    Vector2D(int, int);
    Vector2D(float, float);
    Vector2D(double, double);
    
    Vector2D rotated(double);
    Vector2D toUnit();
    Vector2D scaled(double);
    void rotate(double);
    
    Vector2D operator-();
    void operator+=(Vector2D&);
    void operator-=(Vector2D&);
    void operator*=(double&);
    void operator/=(double&);
    
private:
    void updateCartesian();
    void updatePolar();
};

Vector2D operator+(Vector2D&, Vector2D&);

Vector2D operator-(Vector2D&, Vector2D&);

Vector2D operator*(Vector2D&, double&);

Vector2D operator/(Vector2D&, double&);

bool operator==(Vector2D&, Vector2D&);

bool operator!=(Vector2D&, Vector2D&);

#endif /* Vector2D_hpp */