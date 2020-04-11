//
//  SplinePoint2D.cpp
//  NNTraining
//
//  Created by Michael Schuff on 4/10/20.
//  Copyright © 2020 Michael Schuff. All rights reserved.
//

#include "SplinePoint2D.hpp"


SplinePoint2D::SplinePoint2D(vector<Vector2D> controls, vector<double> multipliers) : Vector2D((float) controls[0].x, (float) controls[0].y), multipliers(multipliers) {
    for (int i = 0; i < controls.size(); i++) {
        this->controlPoints.push_back(Vector2D((float) (multipliers[i] * controls[i].x), (float) (multipliers[i] * controls[i].y)));
    }
}

SplinePoint2D::SplinePoint2D(vector<vector<double>> controls, vector<double> multipliers) : Vector2D((float) controls[0][0], (float) controls[0][1]), multipliers(multipliers) {
    for (int i = 0; i < controls.size(); i++) {
        this->controlPoints.push_back(Vector2D((float) (multipliers[i] * controls[i][0]), (float) (multipliers[i] * controls[i][1])));
    }
}

void SplinePoint2D::SetPositionKeepLocal(double newX, double newY, int baseIndex) {
    Vector2D offset(0, 0);
    for (int i = 0; i <= baseIndex; i++) {
        offset.x += controlPoints[i].x / multipliers[i];
        offset.y += controlPoints[i].y / multipliers[i];
    }
    
    offset.x = multipliers[baseIndex] * (newX - offset.x);
    offset.y = multipliers[baseIndex] * (newY - offset.y);
    
    for (int i = baseIndex; i < controlPoints.size(); i++) {
        this->controlPoints[i] += offset;
    }
}

void SplinePoint2D::SetPosition(double newX, double newY, int baseIndex) {
    Vector2D offset((float) 0, (float) 0);
    for (int i = 0; i <= baseIndex; i++) {
        offset.x += controlPoints[i].x / multipliers[i];
        offset.y += controlPoints[i].y / multipliers[i];
    }
    
    offset.x = multipliers[baseIndex] * (newX - offset.x);
    offset.y = multipliers[baseIndex] * (newY - offset.y);
    
    this->controlPoints[baseIndex] += offset;
    if (baseIndex != controlPoints.size() - 1) {
        this->controlPoints[baseIndex + 1].x -= multipliers[baseIndex + 1] * offset.x / multipliers[baseIndex];
        this->controlPoints[baseIndex + 1].y -= multipliers[baseIndex + 1] * offset.y / multipliers[baseIndex];
    }
}

double SplinePoint2D::GetX(int i) {
    return controlPoints[i].x / multipliers[i];
}

double SplinePoint2D::GetY(int i) {
    return controlPoints[i].y / multipliers[i];
}
